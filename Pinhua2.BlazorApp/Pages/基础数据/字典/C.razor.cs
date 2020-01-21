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

namespace Pinhua2.BlazorApp.Pages.基础数据.字典
{
    public abstract class CBase : _CRUDBase
    {
        protected dto收款单 main = new dto收款单();

        protected KTable2 detailsTableDataSourceTable;
        protected List<dto收款单D> detailsTableDataSource { get; set; } = new List<dto收款单D>();
        protected dto收款单D detailsTableEditingRow { get; set; } = new dto收款单D();

        protected EditModal_收款单明细 EditModal_收款单明细;
        protected Modal_订单金额收付 Modal_订单金额收付;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<view_AllOrdersPay> items)
        {
            if (items.Any())
            {
                var dto_detail = Mapper.Map<view_AllOrdersPay, dto收款单D>(items.ElementAtOrDefault(0));
                detailsTableEditingRow = dto_detail;
                EditModal_收款单明细?.Show();
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal_订单金额收付?.Show();
        }

        protected void saveChange(EditModal_收款单明细 modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto收款单D item)
        {
            bInsert = false;
            detailsTableEditingRow = item;
            EditModal_收款单明细?.Show();
        }

        protected void InvalidSubmit(EditContext context)
        {
            JS.InvokeVoidAsync("klazor.console", JsonConvert.SerializeObject(context, Formatting.Indented));
        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                try
                {
                    var remote = PinhuaContext.RecordAdd<dto收款单, tb_收付表>(main, creating =>
                    {
                        creating.单号 = PinhuaContext.funcAutoCode("订单号");
                        creating.类型 = "收款";
                        creating.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == creating.往来号)?.简称;
                    });

                    if (PinhuaContext.SaveChanges() > 0)
                    {
                        foreach (var localD in detailsTableDataSource)
                        {
                            PinhuaContext.RecordDetailAdd<dto收款单, dto收款单D, tb_收付表, tb_收付表D>(remote, localD, BeforeNewD: beforeD =>
                            {
                                if (string.IsNullOrEmpty(beforeD.子单号))
                                    beforeD.子单号 = PinhuaContext.funcAutoCode("子单号");
                                else
                                {
                                 
                                }
                            });
                        }
                        PinhuaContext.SaveChanges();
                    }

                    Navigation.NavigateTo(routeA);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
