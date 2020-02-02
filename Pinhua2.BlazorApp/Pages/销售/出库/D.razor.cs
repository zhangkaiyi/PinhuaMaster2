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

namespace Pinhua2.BlazorApp.Pages.销售.出库
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto销售出库 main;

        protected KTable2 detailsTable;
        protected List<dto销售出库D> detailsTableDataSource;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto销售出库>(PinhuaContext.GetViews().销售.销售出库(RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto销售出库D>(PinhuaContext.GetViews().销售.销售出库D(RecordId)).ToList();
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
