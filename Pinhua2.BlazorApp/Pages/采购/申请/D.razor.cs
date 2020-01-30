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

        protected dto采购申请 main;

        protected KTable2 detailsTable;
        protected List<dto采购申请D> detailsTableDataSource;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购申请>(PinhuaContext.tb_需求表.AsNoTracking().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购申请D>(PinhuaContext.tb_需求表D.AsNoTracking().Where(m => m.RecordId == RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected async Task toDelete()
        {
            var tb_需求表 = await PinhuaContext.tb_需求表.FindAsync(RecordId);
            if (tb_需求表 != null)
            {
                var tb_需求表D = PinhuaContext.tb_需求表D.Where(p => p.RecordId == tb_需求表.RecordId);

                PinhuaContext.tb_需求表.Remove(tb_需求表);
                PinhuaContext.tb_需求表D.RemoveRange(tb_需求表D);
                await PinhuaContext.SaveChangesAsync();
                Navigation.NavigateTo("/采购/申请");
            }
        }
    }
}
