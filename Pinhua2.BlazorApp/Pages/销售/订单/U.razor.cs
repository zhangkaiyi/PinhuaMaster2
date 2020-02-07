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
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        [Inject] protected RecordManager RecordManager { get; set; }

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
            main = Mapper.Map<dto销售订单>(PinhuaContext.GetViews().销售.销售订单().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto销售订单D>(PinhuaContext.GetViews().销售.销售订单D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
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

        protected void InvalidSubmit(EditContext context)
        {
            JS.InvokeVoidAsync("klazor.console", JsonConvert.SerializeObject(context, Formatting.Indented));
        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var bEdit = PinhuaContext.TryRecordEdit<dto销售订单, tb_订单表>(main, adding =>
                {
                    // 非空字段赋值给跟踪实体
                    adding.业务类型 = base.category;
                    adding.往来 = PinhuaContext.Set<tb_往来表>().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });
                if (bEdit)
                {
                    Action<dto销售订单D> Adding = adding =>
                     {
                         if (string.IsNullOrWhiteSpace(adding.子单号)) // 子单号为空的，表示新插入
                         {
                             adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                         }
                         else if (!string.IsNullOrWhiteSpace(adding.子单号)) // 子单号不为空，表示从报价单引入，插入
                         {
                             var baojiaD = PinhuaContext.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == adding.子单号);
                             if (baojiaD != null)
                                 baojiaD.状态 = "已下单";
                         }
                     };
                    Action<dto销售订单D> Updating = updating =>
                    {
                        var baojiaD = PinhuaContext.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == updating.子单号);
                        if (baojiaD != null)
                            baojiaD.状态 = "已下单";
                    };
                    Action<tb_订单表D> Deleting = deleting =>
                    {
                        var tb_报价D = PinhuaContext.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == deleting.子单号);
                        if (tb_报价D != null)
                            tb_报价D.状态 = "";
                    };

                    var bEdit2 = PinhuaContext.TryRecordDetailsEdit<dto销售订单, dto销售订单D, tb_订单表, tb_订单表D>(main, detailsTableDataSource,
                        Adding, Updating, Deleting
                       );

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
