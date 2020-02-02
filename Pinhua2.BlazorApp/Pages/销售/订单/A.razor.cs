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

namespace Pinhua2.BlazorApp.Pages.销售.订单
{
    public abstract class ABase : _CRUDBase
    {
        protected List<dto销售订单> list_Main { get; set; }
        protected List<dto销售订单D> list_Details { get; set; } = new List<dto销售订单D>();

        protected KTable2 table_Main { get; set; }
        protected KTable2 table_Details { get; set; }

        protected void OnRowClicked(KTable2Event e)
        {
            var row = e.Row as _IBaseTableMain;
            if (row != null)
            {
                list_Details = Mapper.ProjectTo<dto销售订单D>(PinhuaContext.GetViews().销售.销售订单D(row.RecordId)).ToList();
            }
        }

        protected override void OnInitialized()
        {
            list_Main = Mapper.ProjectTo<dto销售订单>(PinhuaContext.GetViews().销售.销售订单()).ToList();
        }
    }
}
