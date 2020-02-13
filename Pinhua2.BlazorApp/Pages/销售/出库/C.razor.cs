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
    public abstract class CBase : _CRUDBase
    {
        protected dto销售出库 main = new dto销售出库();

        protected KTable2 detailsTable;
        protected List<dto销售出库D> detailsTableDataSource { get; set; } = new List<dto销售出库D>();
        protected dto销售出库D detailsTableEditingRow { get; set; } = new dto销售出库D();

        protected Modal_销售订单待发 Modal;
        protected EditModal_销售发货D EditModal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected Expression<Func<view_AllOrdersIO, bool>> Filter { get; set; }

        protected override void OnInitialized()
        {
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
            main.日期 = DateTime.Now;

            Filter = m => m.往来号 == main.往来号 && m.待发 > 0 && !detailsTableDataSource.Any(d => d.子单号 == m.子单号);
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<view_AllOrdersIO> items)
        {
            if (items.Any())
            {
                if (Modal.IsSingleSelect)
                {
                    detailsTableEditingRow = Mapper.Map<view_AllOrdersIO, dto销售出库D>(items.ElementAtOrDefault(0));
                    EditModal?.Show();
                }
                else
                {
                    detailsTableDataSource.AddRange(Mapper.Map<IEnumerable<view_AllOrdersIO>, IEnumerable<dto销售出库D>>(items));
                }
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

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var affected = new List<string>();
                var bAdd = PinhuaContext.TryRecordAdd<dto销售出库, tb_IO>(main, adding =>
                {
                    adding.类型 = base.category;
                    adding.单号 = PinhuaContext.funcAutoCode("订单号");
                    adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });
                if (bAdd)
                {
                    var bAdd2 = PinhuaContext.TryRecordDetailsAdd<dto销售出库, dto销售出库D, tb_IO, tb_IOD>(main, detailsTableDataSource, adding =>
                    {
                        if (string.IsNullOrWhiteSpace(adding.子单号))
                        {
                            adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                        }
                        else
                        {
                            affected.Add(adding.子单号);
                            //var item = PinhuaContext.tb_订单表D.FirstOrDefault(d => d.子单号 == adding.子单号);
                            //if (item != null)
                            //    item.状态 = "已出库";
                        }
                    }
                    );

                    if (bAdd2)
                    {
                        var childIds1 = PinhuaContext.View订单数量收发().Where(d => (d.已发 ?? 0) > 0 && affected.Contains(d.子单号)).Select(d => d.子单号);
                        var childIds2 = PinhuaContext.View订单数量收发().Where(d => (d.已发 ?? 0) == 0 && affected.Contains(d.子单号)).Select(d => d.子单号);
                        var items1 = PinhuaContext.tb_订单表D.Where(d => childIds1.Contains(d.子单号));
                        var items2 = PinhuaContext.tb_订单表D.Where(d => childIds2.Contains(d.子单号));
                        foreach (var item in items1)
                        {
                            item.状态 = "已出库";
                        };
                        foreach (var item in items2)
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
