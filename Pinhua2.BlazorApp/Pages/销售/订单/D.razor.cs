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

namespace Pinhua2.BlazorApp.Pages.销售.订单
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto销售订单 main;

        protected KTable2 detailsTable;
        protected List<dto销售订单D> detailsTableDataSource;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto销售订单>(PinhuaContext.GetViews().销售.销售订单().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto销售订单D>(PinhuaContext.GetViews().销售.销售订单D(RecordId)).ToList();
        }
        protected async Task toDelete()
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var tb_main = await PinhuaContext.tb_订单表.FindAsync(RecordId);
                if (tb_main != null)
                {
                    var tb_details = PinhuaContext.tb_订单表D.Where(p => p.RecordId == tb_main.RecordId);
                    var tb_quo = from d1 in PinhuaContext.tb_报价表D
                                 join d2 in tb_details on d1.子单号 equals d2.子单号
                                 select d1;

                    foreach (var item in tb_quo)
                    {
                        item.状态 = "";
                    }
                    await PinhuaContext.SaveChangesAsync();

                    var mains = from m in PinhuaContext.tb_报价表
                                join d in tb_quo on m.RecordId equals d.RecordId
                                select m;

                    foreach (var m in mains)
                    {
                        var bRet = PinhuaContext.tb_报价表D.Where(d => d.RecordId == m.RecordId).Any(d => d.状态.Contains("已"));
                        if (bRet)
                        {
                            m.LockStatus = 1;
                        }
                        else
                        {
                            m.LockStatus = 0;
                        }
                    };
                    PinhuaContext.tb_订单表.Remove(tb_main);
                    PinhuaContext.tb_订单表D.RemoveRange(tb_details);

                    await PinhuaContext.SaveChangesAsync();

                    transaction.Commit();
                }
            }

            Navigation.NavigateTo(routeA);
        }
    }
}
