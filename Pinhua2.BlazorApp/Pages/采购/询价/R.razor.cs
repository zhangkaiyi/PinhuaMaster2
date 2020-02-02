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
    public abstract class RBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto采购询价 main;

        protected KTable2 detailsTable;
        protected List<dto采购询价D> detailsTableDataSource;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购询价>(PinhuaContext.GetViews().采购.采购询价().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购询价D>(PinhuaContext.GetViews().采购.采购询价D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

    }
}
