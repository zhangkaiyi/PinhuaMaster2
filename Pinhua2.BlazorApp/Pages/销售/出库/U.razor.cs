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

        protected Modal_商品列表_销售订单 Modal_商品列表_销售订单;
        protected Modal_修改销售发货明细 Modal_修改销售发货明细;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto销售出库>(PinhuaContext.GetViews().销售.销售出库(RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto销售出库D>(PinhuaContext.GetViews().销售.销售出库D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<dto销售订单D> items)
        {
            if (items.Any())
            {
                var tb_product = Mapper.Map<dto销售订单D, tb_订单表D>(items.ElementAtOrDefault(0));
                var dto_detail = Mapper.Map<tb_订单表D, dto销售出库D>(tb_product);
                detailsTableEditingRow = dto_detail;
                Modal_修改销售发货明细?.Show();
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal_商品列表_销售订单?.Show();
        }

        protected void saveChange(Modal_修改销售发货明细 modal)
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
            Modal_修改销售发货明细?.Show();
        }

        protected void InvalidSubmit(EditContext context)
        {
            JS.InvokeVoidAsync("klazor.console", JsonConvert.SerializeObject(context, Formatting.Indented));
        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
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
                        else if (!string.IsNullOrEmpty(item.子单号)) // 子单号不为空，表示从报价单引入，插入
                        {
                            var baojiaD = PinhuaContext.Set<tb_订单表D>().FirstOrDefault(d => d.子单号 == item.子单号);
                            if (baojiaD != null)
                                baojiaD.状态 = "已出库";
                        }
                    };

                    Action<dto销售出库D> Updating = item =>
                    {
                        var baojiaD = PinhuaContext.Set<tb_订单表D>().FirstOrDefault(d => d.子单号 == item.子单号);
                        if (baojiaD != null)
                            baojiaD.状态 = "已出库";
                    };

                    Action<tb_IOD> Deleting = item =>
                     {
                         var tb_报价D = PinhuaContext.Set<tb_订单表D>().FirstOrDefault(d => d.子单号 == item.子单号);
                         if (tb_报价D != null)
                             tb_报价D.状态 = "";
                     };
                    var bEdit2 = PinhuaContext.TryRecordDetailsEdit<dto销售出库, dto销售出库D, tb_IO, tb_IOD>(main, detailsTableDataSource, Adding, Updating, Deleting);

                    if (bEdit2)
                    {
                        transaction.Commit();
                    }
                }
              
                Navigation.NavigateTo(routeA);
            }
        }
    }
}
