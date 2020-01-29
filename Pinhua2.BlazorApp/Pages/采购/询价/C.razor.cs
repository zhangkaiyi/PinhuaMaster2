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

namespace Pinhua2.BlazorApp.Pages.采购.询价
{
    public abstract class CBase : _CRUDBase
    {
        protected dto采购询价 main = new dto采购询价();

        protected KTable2 detailsTable;
        protected List<dto采购询价D> detailsTableDataSource { get; set; } = new List<dto采购询价D>();
        protected dto采购询价D detailsTableEditingRow { get; set; } = new dto采购询价D();

        protected EditModal_采购询价D EditModal_采购询价D;
        protected Modal_商品列表_采购申请 Modal_商品列表_采购申请;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<dto采购申请D> items)
        {
            if (items.Any())
            {
                var tb_product = Mapper.Map<dto采购申请D, tb_商品表>(items.ElementAtOrDefault(0));
                var dto_detail = Mapper.Map<tb_商品表, dto采购询价D>(tb_product);
                detailsTableEditingRow = dto_detail;
                EditModal_采购询价D?.Show();
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal_商品列表_采购申请?.Show();
        }

        protected void saveChange(EditModal_采购询价D modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto采购询价D item)
        {
            bInsert = false;
            detailsTableEditingRow = item;
            EditModal_采购询价D?.Show();
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
                    var tb_报价 = PinhuaContext.RecordAdd<dto采购询价, tb_报价表>(main, adding =>
                    {
                        adding.单号 = PinhuaContext.funcAutoCode("订单号");
                        adding.业务类型 = "销售报价";
                        adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                    });
                    if (PinhuaContext.SaveChanges() > 0)
                    {
                        foreach (var dto in detailsTableDataSource)
                        {
                            PinhuaContext.RecordDetailAdd<dto采购询价D, tb_报价表D>(dto, adding =>
                            {
                                adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                                dto.RecordId = tb_报价.RecordId;
                            });
                        }
                        PinhuaContext.SaveChanges();
                        transaction.Commit();
                    }

                    Navigation.NavigateTo("/销售/报价");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
