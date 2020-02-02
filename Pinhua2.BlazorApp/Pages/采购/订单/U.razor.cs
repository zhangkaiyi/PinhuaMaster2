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
        protected Modal_商品列表_采购询价 Modal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购订单>(PinhuaContext.GetViews().采购.采购订单().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购订单D>(PinhuaContext.GetViews().采购.采购订单D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<object> items)
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
            bInsert = true;
            Modal?.Show();
        }

        protected void saveChange(EditModal_采购订单D modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto采购订单D item)
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
                var bEdit = PinhuaContext.TryRecordEdit<dto采购订单, tb_订单表>(main, adding =>
                {
                    adding.业务类型 = "采购订单";
                    adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });
                if (bEdit)
                {
                    var bEdit2 = PinhuaContext.TryRecordDetailsEdit<dto采购订单, dto采购订单D, tb_订单表, tb_订单表D>(main, detailsTableDataSource, adding =>
                    {
                        if (string.IsNullOrEmpty(adding.子单号)) // 子单号为空的，表示新插入
                        {
                            adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                        }
                    });

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
