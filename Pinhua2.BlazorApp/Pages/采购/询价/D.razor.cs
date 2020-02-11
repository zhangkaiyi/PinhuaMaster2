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

namespace Pinhua2.BlazorApp.Pages.采购.询价
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto采购询价 main;

        protected KTable2 detailsTable;
        protected List<dto采购询价D> detailsTableDataSource;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购询价>(PinhuaContext.GetViews().采购.采购询价().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购询价D>(PinhuaContext.GetViews().采购.采购询价D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected async Task toDelete()
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var tb_main = await PinhuaContext.tb_报价表.FindAsync(RecordId);
                if (tb_main != null)
                {
                    var tb_details = PinhuaContext.tb_报价表D.Where(p => p.RecordId == tb_main.RecordId);
                    var tb_requirement = from d1 in PinhuaContext.tb_需求表D
                                     join d2 in tb_details on d1.子单号 equals d2.子单号
                                     select d1;

                    foreach (var item in tb_requirement)
                    {
                        item.状态 = "";
                    }
                    await PinhuaContext.SaveChangesAsync();

                    var mains = from m in PinhuaContext.tb_需求表
                                join d in tb_requirement on m.RecordId equals d.RecordId
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
                    PinhuaContext.tb_报价表.Remove(tb_main);
                    PinhuaContext.tb_报价表D.RemoveRange(tb_details);

                    await PinhuaContext.SaveChangesAsync();

                    transaction.Commit();
                }
            }

            Navigation.NavigateTo(routeA);
        }
    }
}
