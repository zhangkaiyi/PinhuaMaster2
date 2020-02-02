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
using Pinhua2.Data.Models;

namespace Pinhua2.BlazorApp.Pages.销售.出库
{
    public abstract class ABase : _CRUDBase
    {
        protected List<dto销售出库> mainsTableDataSource { get; set; }
        protected List<dto销售出库D> detailsTableDataSource { get; set; } = new List<dto销售出库D>();

        protected KTable2 mainsTable { get; set; }
        protected KTable2 detailsTable { get; set; }

        protected void OnRowClicked(KTable2Event e)
        {
            var row = e.Row as _IBaseTableMain;
            if (row != null)
            {
                detailsTableDataSource = Mapper.ProjectTo<dto销售出库D>(PinhuaContext.GetViews().销售.销售出库D(row.RecordId)).ToList();
            }
        }

        protected override void OnInitialized()
        {
            mainsTableDataSource = Mapper.ProjectTo<dto销售出库>(PinhuaContext.GetViews().销售.销售出库()).ToList();
        }
    }
}
