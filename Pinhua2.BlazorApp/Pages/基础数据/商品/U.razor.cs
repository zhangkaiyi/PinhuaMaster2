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
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace Pinhua2.BlazorApp.Pages.基础数据.商品
{
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto商品 main { get; set; }
        protected string computedSpecification
        {
            get
            {
                if (!main.长度.HasValue || !main.宽度.HasValue || !main.高度.HasValue)
                {
                    return string.Empty;
                }
                else
                {
                    if (!main.面厚.HasValue)
                    {
                        return $"{(double)main.长度}*{(double)main.宽度}*{(double)main.高度}";
                    }
                    else
                    {
                        return $"{(double)main.长度}*{(double)main.宽度}*{(double)main.高度}/{(double)main.面厚}";
                    }
                }
            }
        }

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto商品>(PinhuaContext.tb_商品表.FirstOrDefault(p=>p.RecordId == RecordId));
        }

        protected void InvalidSubmit(EditContext context)
        {
            JS.InvokeVoidAsync("klazor.console", JsonConvert.SerializeObject(context, Formatting.Indented));
        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                try
                {
                    var remote = PinhuaContext.RecordEdit<dto商品, tb_商品表>(main);

                    transaction.Commit();

                    Navigation.NavigateTo(routeA);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
