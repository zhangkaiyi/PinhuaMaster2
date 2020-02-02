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

namespace Pinhua2.BlazorApp.Pages.采购.入库
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto采购入库 main;

        protected KTable2 detailsTable;
        protected List<dto采购入库D> detailsTableDataSource;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购入库>(PinhuaContext.GetViews().采购.采购入库().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购入库D>(PinhuaContext.GetViews().采购.采购入库D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected async Task toDelete()
        {
            var tb_IO = await PinhuaContext.tb_IO.FindAsync(RecordId);
            if (tb_IO != null)
            {
                var tb_IOD = PinhuaContext.tb_IOD.Where(p => p.RecordId == tb_IO.RecordId);

                PinhuaContext.tb_IO.Remove(tb_IO);
                PinhuaContext.tb_IOD.RemoveRange(tb_IOD);
                await PinhuaContext.SaveChangesAsync();
                Navigation.NavigateTo(routeA);
            }
        }
    }
}
