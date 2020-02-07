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

namespace Pinhua2.BlazorApp.Pages.销售.订单
{
    public abstract class CBase : _CRUDBase
    {
        protected dto销售订单 main = new dto销售订单();

        protected KTable2 detailsTable;
        protected List<dto销售订单D> detailsTableDataSource { get; set; } = new List<dto销售订单D>();
        protected dto销售订单D detailsTableEditingRow { get; set; } = new dto销售订单D();

        protected Modal_修改销售订单明细 Modal_修改销售订单明细;
        protected Modal_商品列表 Modal_商品列表;
        protected Modal_商品列表_销售报价D Modal_销售报价D;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
            main.日期 = DateTime.Now;
        }

        protected bool bNew = false;

        protected void selectInsertItem(IEnumerable<dto商品> items)
        {
            if (items.Any())
            {
                var tb_product = Mapper.Map<dto商品, tb_商品表>(items.ElementAtOrDefault(0));
                var dto_detail = Mapper.Map<tb_商品表, dto销售订单D>(tb_product);
                detailsTableEditingRow = dto_detail;
                Modal_修改销售订单明细?.Show();
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
            Modal_销售报价D?.Show();
        }

        protected void selectImportItem(IEnumerable<dto销售报价D> items)
        {
            if (items.Any())
            {
                var dto_detail = Mapper.Map<dto销售报价D, dto销售订单D>(items.ElementAtOrDefault(0));
                detailsTableEditingRow = dto_detail;
                Modal_修改销售订单明细?.Show();
            }
        }

        protected void saveChange(Modal_修改销售订单明细 modal)
        {
            if (bNew)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto销售订单D item)
        {
            bNew = false;
            detailsTableEditingRow = item;
            Modal_修改销售订单明细?.Show();
        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {

                var bAdd = PinhuaContext.TryRecordAdd<dto销售订单, tb_订单表>(main, adding =>
                {
                    adding.业务类型 = base.category;
                    adding.单号 = PinhuaContext.funcAutoCode("订单号");
                    adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });

                if (bAdd)
                {
                    var bAdd2 = PinhuaContext.TryRecordDetailsAdd<dto销售订单, dto销售订单D, tb_订单表, tb_订单表D>(main, detailsTableDataSource, adding =>
                    {
                        if (string.IsNullOrWhiteSpace(adding.子单号))
                        {
                            adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                        }
                        else
                        {
                            var 报价D = PinhuaContext.tb_报价表D.FirstOrDefault(d => d.子单号 == adding.子单号);
                            if (报价D != null)
                                报价D.状态 = "已下单";
                        }
                    });

                    if (bAdd2)
                    {
                        transaction.Commit();
                    }
                }

                Navigation.NavigateTo(routeA);

            }
        }
    }
}
