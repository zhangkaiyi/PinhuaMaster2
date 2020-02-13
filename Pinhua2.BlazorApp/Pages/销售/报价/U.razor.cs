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
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto销售报价 main = new dto销售报价();

        protected KTable2 detailsTable;
        protected List<dto销售报价D> detailsTableDataSource { get; set; } = new List<dto销售报价D>();
        protected dto销售报价D detailsTableEditingRow { get; set; } = new dto销售报价D();

        protected EditModal_销售报价D EditModal;
        protected Modal_商品列表 Modal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto销售报价>(PinhuaContext.GetViews().销售.销售报价().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto销售报价D>(PinhuaContext.GetViews().销售.销售报价D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<dto商品> items)
        {
            if (items.Any())
            {
                if (Modal.IsSingleSelect)
                {
                    detailsTableEditingRow = Mapper.Map<dto商品, dto销售报价D>(items.ElementAtOrDefault(0));
                    EditModal?.Show();
                }
                else
                {
                    detailsTableDataSource.AddRange(Mapper.Map<IEnumerable<dto商品>, IEnumerable<dto销售报价D>>(items));
                }
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal?.Show();
        }

        protected void saveChange(EditModal_销售报价D modal)
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
            EditModal?.Show();
        }

        protected void InvalidSubmit(EditContext context)
        {

        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var bEdit = PinhuaContext.TryRecordEdit<dto销售报价, tb_报价表>(main, editing =>
                {
                    editing.业务类型 = base.category;
                    editing.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == main.往来号)?.简称;
                });

                if (bEdit)
                {
                    var bEdit2 = PinhuaContext.TryRecordDetailsEdit<dto销售报价, dto销售报价D, tb_报价表, tb_报价表D>(main, detailsTableDataSource, adding =>
                    {
                        adding.子单号 = PinhuaContext.funcAutoCode("子单号");
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
