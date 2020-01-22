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
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto往来 main { get; set; }

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto往来>(PinhuaContext.tb_往来表.FirstOrDefault(p => p.RecordId == RecordId));
        }

        protected void HandleValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                try
                {
                    var remote = PinhuaContext.RecordEdit<dto往来, tb_往来表>(main);

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
