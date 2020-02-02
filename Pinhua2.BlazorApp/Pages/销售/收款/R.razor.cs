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

namespace Pinhua2.BlazorApp.Pages.销售.收款
{
    public abstract class RBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto收款单 main;
        protected KTable2 detailsTable;
        protected List<dto收款单D> detailsTableDataSource;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto收款单>(PinhuaContext.GetViews().销售.销售收款(RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto收款单D>(PinhuaContext.GetViews().销售.销售收款D(RecordId)).ToList();
        }

    }
}
