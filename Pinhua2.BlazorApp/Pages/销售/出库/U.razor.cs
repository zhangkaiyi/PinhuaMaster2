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

namespace Pinhua2.BlazorApp.Pages.销售.出库
{
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto销售出库 main = new dto销售出库();

        protected KTable2 detailsTable;
        protected List<dto销售出库D> detailsTableDataSource { get; set; } = new List<dto销售出库D>();
        protected dto销售出库D detailsTableEditingRow { get; set; } = new dto销售出库D();

        protected Modal_销售订单待发 Modal;
        protected EditModal_销售发货D EditModal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto销售出库>(PinhuaContext.GetViews().销售.销售出库(RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto销售出库D>(PinhuaContext.GetViews().销售.销售出库D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<view_AllOrdersIO> items)
        {
            if (items.Any())
            {
                var dto_detail = Mapper.Map<view_AllOrdersIO, dto销售出库D>(items.ElementAtOrDefault(0));
                detailsTableEditingRow = dto_detail;
                EditModal?.Show();
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal?.Show();
        }

        protected void saveChange(EditModal_销售发货D modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto销售出库D item)
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
                var bEdit = PinhuaContext.TryRecordEdit<dto销售出库, tb_IO>(main, adding =>
                {
                    adding.类型 = base.category;
                    adding.往来 = PinhuaContext.Set<tb_往来表>().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });

                if (bEdit)
                {
                    Action<dto销售出库D> Adding = item =>
                    {
                        if (string.IsNullOrEmpty(item.子单号)) // 子单号为空的，表示新插入
                        {
                            item.子单号 = PinhuaContext.funcAutoCode("子单号");
                        }
                        else // 子单号不为空，表示从报价单引入，插入
                        {
                            affected.Add(item.子单号);
                        }
                    };

                    Action<dto销售出库D> Updating = item => affected.Add(item.子单号);
                    Action<tb_IOD> Deleting = item => affected.Add(item.子单号);

                    var bEdit2 = PinhuaContext.TryRecordDetailsEdit<dto销售出库, dto销售出库D, tb_IO, tb_IOD>(main, detailsTableDataSource, Adding, Updating, Deleting);

                    if (bEdit2)
                    {
                        var childIds1 = PinhuaContext.View订单数量收发().Where(d => (d.已发 ?? 0) > 0 && affected.Contains(d.子单号)).Select(d => d.子单号);
                        var childIds2 = PinhuaContext.View订单数量收发().Where(d => (d.已发 ?? 0) == 0 && affected.Contains(d.子单号)).Select(d => d.子单号);
                        var result1 = PinhuaContext.tb_订单表D.Where(d => childIds1.Contains(d.子单号));
                        var result2 = PinhuaContext.tb_订单表D.Where(d => childIds2.Contains(d.子单号));
                        foreach (var item in result1)
                        {
                            item.状态 = "已出库";
                        };
                        foreach (var item in result2)
                        {
                            item.状态 = "";
                        };
                        PinhuaContext.SaveChanges();

                        var mains = from m in PinhuaContext.tb_订单表
                                    join d in PinhuaContext.tb_订单表D on m.RecordId equals d.RecordId
                                    where affected.Contains(d.子单号)
                                    select m;

                        foreach (var m in mains)
                        {
                            var bRet = PinhuaContext.tb_订单表D.Where(d => d.RecordId == m.RecordId).Any(d => d.状态.Contains("已"));
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
