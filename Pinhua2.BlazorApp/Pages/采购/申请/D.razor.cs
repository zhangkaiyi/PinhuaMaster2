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

namespace Pinhua2.BlazorApp.Pages.采购.申请
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto收款单 main;

        protected KTable2 detailsTable;
        protected List<dto收款单D> detailsTableDataSource;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto收款单>(PinhuaContext.tb_收付表.AsNoTracking().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto收款单D>(PinhuaContext.tb_收付表D.AsNoTracking().Where(m => m.RecordId == RecordId)).ToList();
        }

        protected async Task toDelete()
        {
            var tb_收付表 = await PinhuaContext.tb_收付表.FindAsync(RecordId);
            if (tb_收付表 != null)
            {
                var tb_收付表D = PinhuaContext.tb_收付表D.Where(p => p.RecordId == tb_收付表.RecordId);

                PinhuaContext.tb_收付表.Remove(tb_收付表);
                PinhuaContext.tb_收付表D.RemoveRange(tb_收付表D);
                await PinhuaContext.SaveChangesAsync();
                Navigation.NavigateTo(routeA);
            }
        }

    }
}
