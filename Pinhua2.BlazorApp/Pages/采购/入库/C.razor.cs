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

        protected EditModal_采购入库D EditModal;
        protected Modal_商品列表_采购订单 Modal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<object> items)
        {
            if (items.Any())
            {
                var src = items.ElementAtOrDefault(0);
                var srcType = src.GetType();
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
