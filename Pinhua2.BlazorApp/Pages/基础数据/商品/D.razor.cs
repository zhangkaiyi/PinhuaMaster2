﻿using BlazorComponentUtilities;
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

namespace Pinhua2.BlazorApp.Pages.基础数据.商品
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto商品 main;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto商品>(PinhuaContext.GetViews().基础.商品(RecordId));
        }

        protected async Task toDelete()
        {
            var tb_商品表 = await PinhuaContext.tb_商品表.FindAsync(RecordId);
            if (tb_商品表 != null)
            {
                PinhuaContext.tb_商品表.Remove(tb_商品表);
                await PinhuaContext.SaveChangesAsync();
                Navigation.NavigateTo(routeA);
            }
        }
    }
}
