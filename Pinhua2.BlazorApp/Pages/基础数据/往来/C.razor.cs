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

namespace Pinhua2.BlazorApp.Pages.基础数据.往来
{
    public abstract class CBase : _CRUDBase
    {
        protected dto往来 main = new dto往来();

        protected void HandleValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                try
                {
                    var remote = PinhuaContext.RecordAdd<dto往来, tb_往来表>(main, adding =>
                    {
                        adding.往来号 = PinhuaContext.funcAutoCode("往来号");
                    });

                    PinhuaContext.SaveChanges();
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
