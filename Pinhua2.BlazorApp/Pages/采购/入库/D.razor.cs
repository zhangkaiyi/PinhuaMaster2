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

namespace Pinhua2.BlazorApp.Pages.采购.入库
{
    public abstract class DBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto采购入库 main;

        protected KTable2 detailsTable;
        protected List<dto采购入库D> detailsTableDataSource;

        protected List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> dropdownOptions;

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto采购入库>(PinhuaContext.GetViews().采购.采购入库().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto采购入库D>(PinhuaContext.GetViews().采购.采购入库D(RecordId)).ToList();
            dropdownOptions = PinhuaContext.DropdownOptions_客户();
        }

        protected async Task toDelete()
        {
            using (var transaction = PinhuaContext.Database.BeginTransaction())
            {
                var tb_main = await PinhuaContext.tb_IO.FindAsync(RecordId);
                if (tb_main != null)
                {
                    var tb_details = PinhuaContext.tb_IOD.Where(p => p.RecordId == tb_main.RecordId);
                    var affected = tb_details.Select(d => d.子单号).ToList();
                    PinhuaContext.tb_IO.Remove(tb_main);
                    PinhuaContext.tb_IOD.RemoveRange(tb_details);
                    await PinhuaContext.SaveChangesAsync();

                    var childIds1 = PinhuaContext.View订单数量收发().Where(d => (d.已收 ?? 0) > 0 && affected.Contains(d.子单号)).Select(d => d.子单号);
                    var childIds2 = PinhuaContext.View订单数量收发().Where(d => (d.已收 ?? 0) == 0 && affected.Contains(d.子单号)).Select(d => d.子单号);
                    var items1 = PinhuaContext.tb_订单表D.Where(d => childIds1.Contains(d.子单号));
                    var items2 = PinhuaContext.tb_订单表D.Where(d => childIds2.Contains(d.子单号));

                    foreach (var item in items1)
                    {
                        item.状态 = "已入库";
                    };
                    foreach (var item in items2)
                    {
                        item.状态 = "";
                    };

                    await PinhuaContext.SaveChangesAsync();

                    var mains = from m in PinhuaContext.tb_订单表
                                join d in PinhuaContext.tb_订单表D on m.RecordId equals d.RecordId
                                where affected.Contains(d.子单号)
                                select m;

                    foreach (var m in mains)
                    {
                        var bRet = PinhuaContext.tb_订单表D.Where(d => d.RecordId == m.RecordId).Any(d => d.状态.Contains("已"));
                        if (bRet)
                        {
                            m.LockStatus = 1;
                        }
                        else
                        {
                            m.LockStatus = 0;
                        }
                    };

                    await PinhuaContext.SaveChangesAsync();

                    transaction.Commit();
                }
            }

            Navigation.NavigateTo(routeA);
        }
    }
}
