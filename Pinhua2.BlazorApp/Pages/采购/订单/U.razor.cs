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
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

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
            main = Mapper.Map<dto采购订单>(PinhuaContext.GetViews().采购.采购订单().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购订单D>(PinhuaContext.GetViews().采购.采购订单D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bNew = false;

        protected void SelectRows(IEnumerable<object> items)
        {
            if (items.Any())
            {
                var src = items.ElementAtOrDefault(0);
                var srcType = src?.GetType();
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

        protected void saveChange(EditModal_采购订单D modal)
        {
            if (bNew)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto采购订单D item)
        {
            bNew = false;
            detailsTableEditingRow = item;
            EditModal?.Show();
        }

        protected void HandleValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var affected = new List<string>();
                var bEdit = PinhuaContext.TryRecordEdit<dto采购订单, tb_订单表>(main, adding =>
                {
                    adding.业务类型 = base.category;
                    adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });
                if (bEdit)
                {
                    Action<dto采购订单D> Adding = item =>
                    {
                        if (string.IsNullOrWhiteSpace(item.子单号)) // 子单号为空的，表示新插入
                        {
                            item.子单号 = PinhuaContext.funcAutoCode("子单号");
                        }
                        else // 子单号不为空，表示从报价单引入，插入
                        {
                            affected.Add(item.子单号);
                            var baojiaD = PinhuaContext.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == item.子单号);
                            if (baojiaD != null)
                            {
                                baojiaD.状态 = "已下单";
                            }
                        }
                    };
                    Action<dto采购订单D> Updating = item =>
                    {
                        affected.Add(item.子单号);
                        var baojiaD = PinhuaContext.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == item.子单号);
                        if (baojiaD != null)
                        {
                            baojiaD.状态 = "已下单";
                        }
                    };
                    Action<tb_订单表D> Deleting = item =>
                    {
                        affected.Add(item.子单号);
                        var tb_报价D = PinhuaContext.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == item.子单号);
                        if (tb_报价D != null)
                        {
                            tb_报价D.状态 = "";
                        }
                    };

                    var bEdit2 = PinhuaContext.TryRecordDetailsEdit<dto采购订单, dto采购订单D, tb_订单表, tb_订单表D>(main, detailsTableDataSource,
                        Adding, Updating, Deleting);

                    if (bEdit2)
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
