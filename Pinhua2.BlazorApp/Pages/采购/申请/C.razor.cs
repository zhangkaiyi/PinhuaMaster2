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

namespace Pinhua2.BlazorApp.Pages.采购.申请
{
    public abstract class CBase : _CRUDBase
    {
        protected dto采购申请 main = new dto采购申请();

        protected KTable2 detailsTable;
        protected List<dto采购申请D> detailsTableDataSource { get; set; } = new List<dto采购申请D>();
        protected dto采购申请D detailsTableEditingRow { get; set; } = new dto采购申请D();

        protected Modal_商品列表 Modal;
        protected EditModal_采购申请D EditModal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected bool bInsert = false;

        protected void SelectRows(IEnumerable<object> items)
        {
            if (items.Any())
            {
                var src = items.ElementAtOrDefault(0);
                var srcType = items.GetType().GetGenericArguments()[0];
                var dstType = typeof(dto采购申请D);
                var dst = Mapper.Map(src, srcType, dstType);
                detailsTableEditingRow = dst as dto采购申请D;
                EditModal?.Show();
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal?.Show();
        }

        protected void saveChange(EditModal_采购申请D modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto采购申请D item)
        {
            bInsert = false;
            detailsTableEditingRow = item;
            EditModal?.Show();
        }

        protected void HandleValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                try
                {
                    var bAdd = PinhuaContext.TryRecordAdd<dto采购申请, tb_需求表>(main, adding =>
                    {
                        adding.单号 = PinhuaContext.funcAutoCode("订单号");
                        adding.业务类型 = "采购申请";
                    });
                    if (bAdd)
                    {
                        var bAdd2 = PinhuaContext.TryRecordDetailsAdd<dto采购申请, dto采购申请D, tb_需求表, tb_需求表D>(main, detailsTableDataSource, adding =>
                        {
                            if (string.IsNullOrWhiteSpace(adding.子单号))
                            {
                                adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                            }
                        });

                        if (bAdd2)
                        {
                            transaction.Commit();
                        }
                    }

                    Navigation.NavigateTo("/采购/申请");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
