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

namespace Pinhua2.BlazorApp.Pages.采购.付款
{
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto付款单>(PinhuaContext.GetViews().采购.采购付款(RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto付款单D>(PinhuaContext.GetViews().采购.采购付款D(RecordId)).ToList();
        }

        protected dto付款单 main = new dto付款单();

        protected KTable2 detailsTable;
        protected List<dto付款单D> detailsTableDataSource { get; set; } = new List<dto付款单D>();
        protected List<dto付款单D> currentDetails
        {
            get
            {
                RefreshAll可分配金额();
                return detailsTableDataSource;
            }
        }
        protected dto付款单D detailsTableEditingRow { get; set; } = new dto付款单D();
        protected dto付款单D currentEditingRow
        {
            get
            {
                //return RefreshTarget可分配金额(detailsTableEditingRow);
                return detailsTableEditingRow;
            }
            set
            {
                detailsTableEditingRow = value;
            }
        }

        protected EditModal_付款单明细 EditModal;
        protected Modal_订单金额待付 Modal;

        protected bool IsNewRow = false;

        protected void toSelect(IEnumerable<view_AllOrdersPay> items)
        {
            if (items.Any())
            {
                if (Modal.IsSingleSelect)
                {

                    currentEditingRow = Mapper.Map<view_AllOrdersPay, dto付款单D>(items.ElementAtOrDefault(0));
                    EditModal?.Show();
                }
                else
                {
                    detailsTableDataSource.AddRange(Mapper.Map<IEnumerable<view_AllOrdersPay>, IEnumerable<dto付款单D>>(items));
                }
            }
        }

        protected void NewRow()
        {
            IsNewRow = true;
            currentEditingRow = new dto付款单D();
            Modal?.Show();
        }

        protected void EditRow(dto付款单D item)
        {
            IsNewRow = false;
            currentEditingRow = item;
            EditModal?.Show();
        }

        protected void SaveRow(EditModal_付款单明细 modal)
        {
            if (IsNewRow)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
            currentEditingRow = new dto付款单D();
        }

        protected void RemoveRow(dto付款单D item)
        {
            detailsTableDataSource.Remove(item);
        }

        protected void RefreshAll可分配金额()
        {
            foreach (var item in detailsTableDataSource)
            {
                var i = detailsTableDataSource.IndexOf(item);
                var 总金额 = main.付;
                var 已分配 = detailsTableDataSource.GetRange(0, i).Sum(item => item.可分配);
                var 未分配 = 总金额 - 已分配;
                if (item.待付款额 <= 未分配)
                {
                    item.可分配 = item.待付款额;
                }
                else
                {
                    item.可分配 = 未分配;
                }
            }
        }

        protected void HandelValidSubmit(EditContext context)
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var bSuccess1 = PinhuaContext.TryRecordEdit<dto付款单, tb_收付表>(main, creating =>
                {
                    creating.类型 = base.category;
                    creating.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == creating.往来号)?.简称;
                });
                if (bSuccess1)
                {
                    var bSuccess2 = PinhuaContext.TryRecordDetailsEdit<dto付款单, dto付款单D, tb_收付表, tb_收付表D>(main, currentDetails, adding =>
                     {
                         if (string.IsNullOrWhiteSpace(adding.子单号))
                         {
                             adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                         }
                     });
                    if (bSuccess2)
                    {
                        transaction.Commit();
                    }
                }

                Navigation.NavigateTo(routeA);
            }
        }
    }
}
