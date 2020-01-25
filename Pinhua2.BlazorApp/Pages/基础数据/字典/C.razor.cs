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

namespace Pinhua2.BlazorApp.Pages.基础数据.字典
{
    public abstract class CBase : _CRUDBase
    {
        protected dto字典 main = new dto字典();

        protected KTable2 detailsTable;
        protected List<dto字典D> detailsTableDataSource { get; set; } = new List<dto字典D>();
        protected dto字典D detailsTableEditingRow { get; set; } = new dto字典D();

        protected EditModal_字典明细 EditModal_字典明细;

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<view_AllOrdersPay> items)
        {
            if (items.Any())
            {
                var dto_detail = Mapper.Map<view_AllOrdersPay, dto字典D>(items.ElementAtOrDefault(0));
                detailsTableEditingRow = dto_detail;
                EditModal_字典明细?.Show();
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            detailsTableEditingRow = new dto字典D();
            EditModal_字典明细?.Show();
        }

        protected void saveChange(EditModal_字典明细 modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto字典D item)
        {
            bInsert = false;
            detailsTableEditingRow = item;
            EditModal_字典明细?.Show();
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
                    var bAdd1 = PinhuaContext.TryRecordAdd<dto字典, tb_字典表>(main);
                    if (bAdd1)
                    {
                        var bAdd2 = PinhuaContext.TryRecordDetailsAdd<dto字典, dto字典D, tb_字典表, tb_字典表D>(main, detailsTableDataSource, adding =>
                        {
                            foreach(var item in detailsTableDataSource)
                            {
                                item.字典号 = main.字典号;
                                item.组号 = main.组号;
                            }
                        });
                        if (bAdd2)
                        {
                            transaction.Commit();
                        }
                    }

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
