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
    public abstract class UBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto采购申请 main = new dto采购申请();

        protected KTable2 detailsTable;
        protected List<dto采购申请D> detailsTableDataSource { get; set; } = new List<dto采购申请D>();
        protected dto采购申请D detailsTableEditingRow { get; set; } = new dto采购申请D();

        protected Modal_销售订单 Modal_销售订单;
        protected Modal_销售订单D Modal_销售订单D;
        protected EditModal_采购申请D EditModal;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购申请>(PinhuaContext.GetViews().采购.采购申请().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购申请D>(PinhuaContext.GetViews().采购.采购申请D(RecordId)).ToList();
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
            Modal_销售订单?.Show();
        }

        protected void toImport(object order)
        {
            detailsTableDataSource.Clear();
            if (order is dto销售订单 dto)
            {
                main.往来单号 = dto.单号;
                var details = PinhuaContext.tb_订单表D.Where(d => d.RecordId == dto.RecordId).OrderBy(d => d.RN);
                detailsTableDataSource = Mapper.ProjectTo<dto采购申请D>(details).ToList();
            }
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
                var bAdd = PinhuaContext.TryRecordEdit<dto采购申请, tb_需求表>(main, adding =>
                {
                    adding.业务类型 = "采购申请";
                });
                if (bAdd)
                {
                    var bAdd2 = PinhuaContext.TryRecordDetailsEdit<dto采购申请, dto采购申请D, tb_需求表, tb_需求表D>(main, detailsTableDataSource,
                        adding =>
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
        }
    }
}
