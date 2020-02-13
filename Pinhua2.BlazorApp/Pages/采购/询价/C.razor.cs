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

namespace Pinhua2.BlazorApp.Pages.采购.询价
{
    public abstract class CBase : _CRUDBase
    {
        protected dto采购询价 main = new dto采购询价();

        protected KTable2 detailsTable;
        protected List<dto采购询价D> detailsTableDataSource { get; set; } = new List<dto采购询价D>();
        protected dto采购询价D detailsTableEditingRow { get; set; } = new dto采购询价D();

        protected Modal_商品列表 Modal_商品列表;
        protected Modal_采购申请 Modal_采购申请;
        protected Modal_采购申请D Modal_采购申请D;
        protected EditModal_采购询价D EditModal;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;
        protected Expression<Func<combo采购申请, bool>> Filter { get; set; }

        protected override void OnInitialized()
        {
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
            main.日期 = DateTime.Now;

            Filter = model => !detailsTableDataSource.Any(s => s.子单号 == model.Detail.子单号) && !(model.Detail.状态 ?? string.Empty).Contains("已");
        }

        protected bool bInsert = false;

        protected void toSelect(IEnumerable<object> items)
        {
            if (items.Any())
            {
                var src = items.ElementAtOrDefault(0);
                var srcType = src?.GetType();
                var dstType = detailsTableEditingRow?.GetType();
                var dst = Mapper.Map(src, srcType, dstType);
                detailsTableEditingRow = dst as dto采购询价D;
                EditModal?.Show();
            }
        }

        protected void ShowDataSource()
        {
            bInsert = true;
            if (main.来自需求单)
            {
                Modal_采购申请D?.Show();
            }
            else
            {
                Modal_商品列表?.Show();
            }
        }

        protected void ImportDataSource(IEnumerable<dto商品> items)
        {
            if (items.Any())
            {
                if (Modal_商品列表.IsSingleSelect)
                {
                    detailsTableEditingRow = Mapper.Map<dto商品, dto采购询价D>(items.ElementAtOrDefault(0));
                    EditModal?.Show();
                }
                else
                {
                    detailsTableDataSource.AddRange(Mapper.Map<IEnumerable<dto商品>, IEnumerable<dto采购询价D>>(items));
                }
            }
        }

        protected void ImportDataSource(IEnumerable<dto采购申请D> items)
        {
            if (items.Any())
            {
                if (Modal_采购申请D.IsSingleSelect)
                {
                    detailsTableEditingRow = Mapper.Map<dto采购申请D, dto采购询价D>(items.ElementAtOrDefault(0));
                    EditModal?.Show();
                }
                else
                {
                    detailsTableDataSource.AddRange(Mapper.Map<IEnumerable<dto采购申请D>, IEnumerable<dto采购询价D>>(items));
                }
            }
        }

        protected void toInsert()
        {
            bInsert = true;
            Modal_采购申请D?.Show();
        }

        protected void saveChange(EditModal_采购询价D modal)
        {
            if (bInsert)
            {
                detailsTableDataSource.Add(modal.DataSource);
            }
        }

        protected void toEdit(dto采购询价D item)
        {
            bInsert = false;
            detailsTableEditingRow = item;
            EditModal?.Show();
        }

        protected void toImport(object order)
        {
            detailsTableDataSource.Clear();
            if (order is dto采购申请 dto)
            {
                main.需求单 = dto.单号;
                var details = PinhuaContext.tb_需求表D.Where(d => d.RecordId == dto.RecordId).OrderBy(d => d.RN);
                detailsTableDataSource = Mapper.ProjectTo<dto采购询价D>(details).ToList();
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
                var affected = new List<string>();
                var bAdd = PinhuaContext.TryRecordAdd<dto采购询价, tb_报价表>(main, adding =>
                {
                    adding.单号 = PinhuaContext.funcAutoCode("订单号");
                    adding.业务类型 = base.category;
                    adding.往来 = PinhuaContext.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == adding.往来号)?.简称;
                });
                if (bAdd)
                {
                    var bAdd2 = PinhuaContext.TryRecordDetailsAdd<dto采购询价, dto采购询价D, tb_报价表, tb_报价表D>(main, detailsTableDataSource, adding =>
                    {
                        if (string.IsNullOrWhiteSpace(adding.子单号))
                        {
                            adding.子单号 = PinhuaContext.funcAutoCode("子单号");
                        }
                        else
                        {
                            affected.Add(adding.子单号);
                            var item = PinhuaContext.tb_需求表D.FirstOrDefault(d => d.子单号 == adding.子单号);
                            if (item != null)
                            {
                                item.状态 = "已询价";
                            }
                        }
                    });

                    if (bAdd2)
                    {
                        var mains = from m in PinhuaContext.tb_需求表
                                    join d in PinhuaContext.tb_需求表D on m.RecordId equals d.RecordId
                                    where affected.Contains(d.子单号)
                                    select m;

                        foreach (var m in mains)
                        {
                            var bRet = PinhuaContext.tb_需求表D.Where(d => d.RecordId == m.RecordId).Any(d => d.状态.Contains("已"));
                            if (bRet)
                            {
                                m.LockStatus = 1;
                            }
                            else
                            {
                                m.LockStatus = 0;
                            }
                        };
                        PinhuaContext.SaveChanges();

                        transaction.Commit();
                    }
                }

                Navigation.NavigateTo(routeA);
            }
        }
    }
}
