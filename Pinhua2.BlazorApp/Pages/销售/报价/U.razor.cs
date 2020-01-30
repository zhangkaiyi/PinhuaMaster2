using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.DataAnnotations;
using System.Linq.Expressions;
using Pinhua2.ViewModels;
using Klazor;
using AutoMapper;
using Pinhua2.Data;
using Microsoft.EntityFrameworkCore;
using Pinhua2.BlazorApp.Pages.Components;
using Piuhua2.Components.Modal;
using Pinhua2.Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace Pinhua2.BlazorApp.Pages.销售.报价
{
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto销售报价 main = new dto销售报价();

        protected KTable2 detailsTable;
        protected List<dto销售报价D> detailsTableDataSource { get; set; } = new List<dto销售报价D>();
        protected dto销售报价D detailsTableEditingRow { get; set; } = new dto销售报价D();

        protected Modal_修改销售报价明细 Modal_修改销售报价明细;
        protected Modal_商品列表 Modal_商品列表;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto销售报价>(PinhuaContext.tb_报价表.AsNoTracking().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto销售报价D>(PinhuaContext.tb_报价表D.AsNoTracking().Where(m => m.RecordId == RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<dto商品> items)
        {
            if (items.Any())
            {
                var tb_product = Mapper.Map<dto商品, tb_商品表>(items.ElementAtOrDefault(0));
                var dto_detail = Mapper.Map<tb_商品表, dto销售报价D>(tb_product);
                detailsTableEditingRow = dto_detail;
                Modal_修改销售报价明细?.Show();
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal_商品列表?.Show();
        }

        protected void saveChange(Modal_修改销售报价明细 modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto销售报价D item)
        {
            bInsert = false;
            detailsTableEditingRow = item;
            Modal_修改销售报价明细?.Show();
        }

        protected void InvalidSubmit(EditContext context)
        {

        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                try
                {
                    var remote = PinhuaContext.tb_报价表.FirstOrDefault(m => m.RecordId == main.RecordId);
                    if (remote == null)
                        return;

                    // 非空字段赋值给跟踪实体
                    main.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == main.往来号)?.简称;
                    // 修改时间
                    main.LastEditTime = DateTime.Now;
                    main.LastEditUser = main.LastEditUser ?? "张凯译";

                    Mapper.Map<dto销售报价, tb_报价表>(main, remote);

                    var remoteDetails = PinhuaContext.tb_报价表D.Where(d => d.RecordId == remote.RecordId);

                    // 数据库中的子单号与新明细中没有相同的，则从数据库中删除
                    foreach (var remoteD in remoteDetails)
                    {
                        if (!detailsTableDataSource.Where(p => !string.IsNullOrEmpty(p.子单号)).Any(p => p.子单号 == remoteD.子单号))
                            PinhuaContext.tb_报价表D.Remove(remoteD);
                    }
                    // 新明细中的子单号为空，则添加
                    foreach (var localD in detailsTableDataSource.Where(p => string.IsNullOrEmpty(p.子单号)))
                    {
                        localD.RecordId = remote.RecordId;
                        localD.子单号 = PinhuaContext.funcAutoCode("子单号");
                        PinhuaContext.tb_报价表D.Add(Mapper.Map<tb_报价表D>(localD));
                    }
                    // 子单号相同，则赋值
                    foreach (var localD in detailsTableDataSource.Where(p => !string.IsNullOrEmpty(p.子单号)))
                    {
                        foreach (var remoteD in remoteDetails)
                        {
                            if (remoteD.子单号 == localD.子单号)
                            {
                                Mapper.Map<dto销售报价D, tb_报价表D>(localD, remoteD);
                                break;
                            }
                        }
                    }

                    PinhuaContext.SaveChanges();
                    transaction.Commit();

                    Navigation.NavigateTo("/销售/报价");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

        }
    }
}
