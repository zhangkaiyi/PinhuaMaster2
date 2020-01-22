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

namespace Pinhua2.BlazorApp.Pages.基础数据.往来
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto往来 main = new dto往来();

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto往来>(PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(m => m.RecordId == RecordId));
        }

        protected async Task toDelete()
        {
            var tb_往来表 = await PinhuaContext.tb_往来表.FindAsync(RecordId);
            if (tb_往来表 != null)
            {
                PinhuaContext.tb_往来表.Remove(tb_往来表);
                await PinhuaContext.SaveChangesAsync();
                Navigation.NavigateTo(routeA);
            }
        }

    }
}
