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

        protected EditModal_销售发货D EditModal;
        protected Modal_商品列表_销售订单 Modal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
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

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
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
                            var item = PinhuaContext.tb_订单表D.FirstOrDefault(d => d.子单号 == adding.子单号);
                            if (item != null)
                                item.状态 = "已出库";
                        }
                    }
                    );

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
