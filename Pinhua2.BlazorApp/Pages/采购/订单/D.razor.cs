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

namespace Pinhua2.BlazorApp.Pages.采购.订单
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto采购订单 main;

        protected KTable2 detailsTable;
        protected List<dto采购订单D> detailsTableDataSource;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购订单>(PinhuaContext.GetViews().采购订单().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购订单D>(PinhuaContext.GetViews().采购订单D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected async Task toDelete()
        {
            var tb_订单表 = await PinhuaContext.tb_订单表.FindAsync(RecordId);
            if (tb_订单表 != null)
            {
                var tb_订单表D = PinhuaContext.tb_订单表D.Where(p => p.RecordId == tb_订单表.RecordId);

                PinhuaContext.tb_订单表.Remove(tb_订单表);
                PinhuaContext.tb_订单表D.RemoveRange(tb_订单表D);
                await PinhuaContext.SaveChangesAsync();
                Navigation.NavigateTo(routeA);
            }
        }
    }
}
