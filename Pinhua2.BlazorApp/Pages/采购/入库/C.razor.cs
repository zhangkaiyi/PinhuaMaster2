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

namespace Pinhua2.BlazorApp.Pages.采购.入库
{
    public abstract class CBase : _CRUDBase
    {
        protected dto采购入库 main = new dto采购入库();

        protected KTable2 detailsTable;
        protected List<dto采购入库D> detailsTableDataSource { get; set; } = new List<dto采购入库D>();
        protected dto采购入库D detailsTableEditingRow { get; set; } = new dto采购入库D();

        protected Modal_采购订单待收 Modal;
        protected EditModal_采购入库D EditModal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected Expression<Func<view_AllOrdersIO, bool>> Filter { get; set; }

        protected override void OnInitialized()
        {
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
            main.日期 = DateTime.Now;

            Filter = m => m.往来号 == main.往来号 && m.待收 > 0;
        }

        protected bool bInsert = false;

        protected void ImportDataSource(IEnumerable<view_AllOrdersIO> items)
        {
            if (items.Any())
            {
                if (Modal.IsSingleSelect)
                {
                    detailsTableEditingRow = Mapper.Map<view_AllOrdersIO, dto采购入库D>(items.ElementAtOrDefault(0));
                    EditModal?.Show();
                }
                else
                {
                    detailsTableDataSource.AddRange(Mapper.Map<IEnumerable<view_AllOrdersIO>, IEnumerable<dto采购入库D>>(items));
                }
            }
        }

        protected void SelectRows(IEnumerable<object> items)
        {
            if (items.Any())
            {
                var src = items.ElementAtOrDefault(0);
                var srcType = src?.GetType();
                var dstType = detailsTableEditingRow?.GetType();
                var dst = Mapper.Map(src, srcType, dstType);
                detailsTableEditingRow = dst as dto采购入库D;
                EditModal?.Show();
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal?.Show();
        }

        protected void saveChange(EditModal_采购入库D modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto采购入库D item)
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
                var bAdd = PinhuaContext.TryRecordAdd<dto采购入库, tb_IO>(main, adding =>
                {
                    adding.单号 = PinhuaContext.funcAutoCode("订单号");
                    adding.类型 = category;
                    adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });
                if (bAdd)
                {
                    var bAdd2 = PinhuaContext.TryRecordDetailsAdd<dto采购入库, dto采购入库D, tb_IO, tb_IOD>(main, detailsTableDataSource, adding =>
                    {
                        if (string.IsNullOrWhiteSpace(adding.子单号))
                        {
                            adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                        }
                        else
                        {
                            affected.Add(adding.子单号);
                        }
                    });

                    if (bAdd2)
                    {
                        var childIds1 = PinhuaContext.View订单数量收发().Where(d => (d.已收 ?? 0) > 0 && affected.Contains(d.子单号)).Select(d => d.子单号);
                        var childIds2 = PinhuaContext.View订单数量收发().Where(d => (d.已收 ?? 0) == 0 && affected.Contains(d.子单号)).Select(d => d.子单号);
                        var items1 = PinhuaContext.tb_订单表D.Where(d => childIds1.Contains(d.子单号));
                        var items2 = PinhuaContext.tb_订单表D.Where(d => childIds2.Contains(d.子单号));
                        foreach (var item in items1)
                        {
                            item.状态 = "已入库";
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
