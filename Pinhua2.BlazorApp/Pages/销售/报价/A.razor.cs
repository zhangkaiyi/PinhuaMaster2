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

namespace Pinhua2.BlazorApp.Pages.销售.报价
{
    public abstract class ABase : _CRUDBase
    {
        protected KTable2 mainsTable { get; set; }
        protected List<dto销售报价> mainsTableDataSource { get; set; }

        protected KTable2 detailsTable { get; set; }
        protected List<dto销售报价D> detailsTableDataSource { get; set; } = new List<dto销售报价D>();

        protected void OnRowClicked(KTable2Event e)
        {
            var row = e.Row as _IBaseTableMain;
            if (row != null)
            {
                detailsTableDataSource = Mapper.ProjectTo<dto销售报价D>(PinhuaContext.GetViews().销售.销售报价D(row.RecordId)).ToList();
            }
        }

        protected override void OnInitialized()
        {
            mainsTableDataSource = Mapper.ProjectTo<dto销售报价>(PinhuaContext.GetViews().销售.销售报价()).ToList();
        }
    }
}
