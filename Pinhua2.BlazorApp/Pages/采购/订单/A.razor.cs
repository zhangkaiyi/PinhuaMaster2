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

namespace Pinhua2.BlazorApp.Pages.采购.订单
{
    public abstract class ABase : _CRUDBase
    {
        protected KTable2 mainsTable { get; set; }
        protected List<dto采购订单> mainsTableDataSource { get; set; }

        protected KTable2 detailsTable { get; set; }
        protected List<dto采购订单D> detailsTableDataSource { get; set; } = new List<dto采购订单D>();

        protected void OnRowClicked(KTable2Event e)
        {
            var row = e.Row as _IBaseTableMain;
            if (row != null)
            {
                detailsTableDataSource = Mapper.ProjectTo<dto采购订单D>(PinhuaContext.tb_订单表D.AsNoTracking().Where(m => m.RecordId == row.RecordId)).ToList();
            }
        }

        protected override void OnInitialized()
        {
            mainsTableDataSource = Mapper.ProjectTo<dto采购订单>(PinhuaContext.tb_订单表).ToList();
        }
    }
}
