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

namespace Pinhua2.BlazorApp.Pages.采购.询价
{
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto采购询价 main = new dto采购询价();

        protected KTable2 detailsTable;
        protected List<dto采购询价D> detailsTableDataSource { get; set; } = new List<dto采购询价D>();
        protected dto采购询价D detailsTableEditingRow { get; set; } = new dto采购询价D();

        protected Modal_采购申请 Modal_采购申请;
        protected Modal_采购申请D Modal_采购申请D;
        protected EditModal_采购询价D EditModal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购询价>(PinhuaContext.GetViews().采购.采购询价().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购询价D>(PinhuaContext.GetViews().采购.采购询价D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<object> items)
        {
            if (items.Any())
            {
                var src = items.ElementAtOrDefault(0);
                var srcType = src?.GetType();
                var dstType = detailsTableEditingRow?.GetType();
                var dst = Mapper.Map(src, srcType, dstType);
                detailsTableEditingRow = dst as dto采购询价D;
                EditModal?.Show();
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal_采购申请D?.Show();
        }

        protected void toImport(object order)
        {
            detailsTableDataSource.Clear();
            if (order is dto采购申请 dto)
            {
                main.需求单 = dto.单号;
                var details = PinhuaContext.tb_需求表D.Where(d => d.RecordId == dto.RecordId).OrderBy(d => d.RN);
                detailsTableDataSource = Mapper.ProjectTo<dto采购询价D>(details).ToList();
            }
        }

        protected void saveChange(EditModal_采购询价D modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto采购询价D item)
        {
            bInsert = false;
            detailsTableEditingRow = item;
            EditModal?.Show();
        }

        protected void InvalidSubmit(EditContext context)
        {
            JS.InvokeVoidAsync("klazor.console", JsonConvert.SerializeObject(context, Formatting.Indented));
        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var affected = new List<string>();
                var bEdit = PinhuaContext.TryRecordEdit<dto采购询价, tb_报价表>(main, adding =>
                {
                    adding.业务类型 = base.category;
                    adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });
                if (bEdit)
                {
                    Action<dto采购询价D> Adding = adding =>
                    {
                        if (string.IsNullOrEmpty(adding.子单号)) // 子单号为空的，表示新插入
                        {
                            adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                        }
                        else
                        {
                            affected.Add(adding.子单号);
                            var item = PinhuaContext.Set<tb_需求表D>().FirstOrDefault(d => d.子单号 == adding.子单号);
                            if (item != null)
                            {
                                item.状态 = "已询价";
                            }
                        }
                    };
                    Action<dto采购询价D> Updating = item =>
                    {
                        affected.Add(item.子单号);
                        var baojiaD = PinhuaContext.Set<tb_需求表D>().FirstOrDefault(d => d.子单号 == item.子单号);
                        if (baojiaD != null)
                        {
                            baojiaD.状态 = "已询价";
                        }
                    };
                    Action<tb_报价表D> Deleting = item =>
                    {
                        affected.Add(item.子单号);
                        var tb_报价D = PinhuaContext.Set<tb_需求表D>().FirstOrDefault(d => d.子单号 == item.子单号);
                        if (tb_报价D != null)
                        {
                            tb_报价D.状态 = "";
                        }
                    };

                    var bEdit2 = PinhuaContext.TryRecordDetailsEdit<dto采购询价, dto采购询价D, tb_报价表, tb_报价表D>(main, detailsTableDataSource,
                        Adding, Updating, Deleting);

                    if (bEdit2)
                    {
                        var mains = from m in PinhuaContext.tb_需求表
                                    join d in PinhuaContext.tb_需求表D on m.RecordId equals d.RecordId
                                    where affected.Contains(d.子单号)
                                    select m;

                        foreach (var m in mains)
                        {
                            var bRet = PinhuaContext.tb_需求表D.Where(d => d.RecordId == m.RecordId).Any(d => d.状态.Contains("已"));
                            if (bRet)
                            {
                                m.LockStatus = 1;
                            }
                            else
                            {
                                m.LockStatus = 0;
                            }
                        };
                        PinhuaContext.SaveChanges();

                        transaction.Commit();
                    }
                }

                Navigation.NavigateTo(routeA);
            }
        }
    }
}
