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

namespace Pinhua2.BlazorApp.Pages.采购.订单
{
    public abstract class CBase : _CRUDBase
    {
        protected dto采购订单 main = new dto采购订单();

        protected KTable2 detailsTable;
        protected List<dto采购订单D> detailsTableDataSource { get; set; } = new List<dto采购订单D>();
        protected dto采购订单D detailsTableEditingRow { get; set; } = new dto采购订单D();

        protected EditModal_采购订单D EditModal;
        protected Modal_商品列表 Modal_商品列表;
        protected Modal_采购询价D Modal_采购询价D;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bNew = false;

        protected void SelectRows(IEnumerable<object> items)
        {
            if (items.Any())
            {
                var srcType = items.GetType().GetGenericArguments()[0];
                var src = items.ElementAtOrDefault(0);
                var dstType = detailsTableEditingRow?.GetType();
                var dst = Mapper.Map(src, srcType, dstType);
                detailsTableEditingRow = dst as dto采购订单D;
                EditModal?.Show();
            }
        }

        protected void toInsert()
        {
            bNew = true;
            Modal_商品列表?.Show();
        }

        protected void toImport()
        {
            bNew = true;
            Modal_采购询价D?.Show();
        }

        protected void toEdit(dto采购订单D item)
        {
            bNew = false;
            detailsTableEditingRow = item;
            EditModal?.Show();
        }

        protected void saveChange(EditModal_采购订单D modal)
        {
            if (bNew)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void HandleValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var affected = new List<string>();
                var bAdd = PinhuaContext.TryRecordAdd<dto采购订单, tb_订单表>(main, adding =>
                {
                    adding.单号 = PinhuaContext.funcAutoCode("订单号");
                    adding.业务类型 = base.category;
                    adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });
                if (bAdd)
                {
                    var bAdd2 = PinhuaContext.TryRecordDetailsAdd<dto采购订单, dto采购订单D, tb_订单表, tb_订单表D>(main, detailsTableDataSource, adding =>
                    {
                        if (string.IsNullOrWhiteSpace(adding.子单号))
                        {
                            adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                        }
                        else
                        {
                            affected.Add(adding.子单号);
                            var 报价D = PinhuaContext.tb_报价表D.FirstOrDefault(d => d.子单号 == adding.子单号);
                            if (报价D != null)
                            {
                                报价D.状态 = "已下单";
                            }
                        }
                    });

                    if (bAdd2)
                    {
                        var mains = from m in PinhuaContext.tb_报价表
                                    join d in PinhuaContext.tb_报价表D on m.RecordId equals d.RecordId
                                    where affected.Contains(d.子单号)
                                    select m;

                        foreach (var m in mains)
                        {
                            var bRet = PinhuaContext.tb_报价表D.Where(d => d.RecordId == m.RecordId).Any(d => d.状态.Contains("已"));
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

        protected void HandleAdd()
        {
            if (main.来自报价单)
            {
                toImport();
            }
            else
            {
                toInsert();
            }
        }

        protected void HandleCancel()
        {
            Navigation.NavigateTo(routeA);
        }
    }
}
