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

namespace Pinhua2.BlazorApp.Pages.采购.询价
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto采购询价 main;

        protected KTable2 detailsTable;
        protected List<dto采购询价D> detailsTableDataSource;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购询价>(PinhuaContext.tb_报价表.AsNoTracking().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购询价D>(PinhuaContext.tb_报价表D.AsNoTracking().Where(m => m.RecordId == RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected async Task toDelete()
        {
            var tb_报价表 = await PinhuaContext.tb_报价表.FindAsync(RecordId);
            if (tb_报价表 != null)
            {
                var tb_报价表D = PinhuaContext.tb_报价表D.Where(p => p.RecordId == tb_报价表.RecordId);

                PinhuaContext.tb_报价表.Remove(tb_报价表);
                PinhuaContext.tb_报价表D.RemoveRange(tb_报价表D);
                await PinhuaContext.SaveChangesAsync();
                Navigation.NavigateTo(routeA);
            }
        }
    }
}
