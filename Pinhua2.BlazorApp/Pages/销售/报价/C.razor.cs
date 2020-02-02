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
    public abstract class CBase : _CRUDBase
    {
        protected dto销售报价 main = new dto销售报价();

        protected KTable2 detailsTable;
        protected List<dto销售报价D> detailsTableDataSource { get; set; } = new List<dto销售报价D>();
        protected dto销售报价D detailsTableEditingRow { get; set; } = new dto销售报价D();

        protected Modal_修改销售报价明细 Modal_修改销售报价明细;
        protected Modal_商品列表 Modal_商品列表;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
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
            JS.InvokeVoidAsync("klazor.console", JsonConvert.SerializeObject(context, Formatting.Indented));
        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var bAdd = PinhuaContext.TryRecordAdd<dto销售报价, tb_报价表>(main, adding =>
                {
                    adding.业务类型 = base.category;
                    adding.单号 = PinhuaContext.funcAutoCode("订单号");
                    adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });
                if (bAdd)
                {
                    var bAdd2 = PinhuaContext.TryRecordDetailsAdd<dto销售报价, dto销售报价D, tb_报价表, tb_报价表D>(main, detailsTableDataSource, adding =>
                    {
                        adding.子单号 = PinhuaContext.funcAutoCode("子单号");
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
