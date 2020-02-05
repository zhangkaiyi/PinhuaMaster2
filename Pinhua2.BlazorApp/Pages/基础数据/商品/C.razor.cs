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
using Piuhua2.Components.Modal;
using Pinhua2.Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace Pinhua2.BlazorApp.Pages.基础数据.商品
{
    public abstract class CBase : _CRUDBase
    {
        protected dto商品 main = new dto商品();

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
                        return $"{main.长度}*{main.宽度}*{main.高度}";
                    }
                    else
                    {
                        return $"{main.长度}*{main.宽度}*{main.高度}/{main.面厚}";
                    }
                }
            }
        }

        protected void InvalidSubmit(EditContext context)
        {
            JS.InvokeVoidAsync("klazor.console", JsonConvert.SerializeObject(context, Formatting.Indented));
        }

        protected void ValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var bAdd = PinhuaContext.TryRecordAdd<dto商品, tb_商品表>(main, adding =>
                {
                    adding.品号 = PinhuaContext.funcAutoCode("商品号");
                });

                if (bAdd)
                {
                    transaction.Commit();
                }

                Navigation.NavigateTo(routeA);
            }
        }
    }
}
