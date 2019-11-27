using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.销售.销售订单
{
    public class CreateModel : PageModel
    {
        private readonly Pinhua2Context _context;
        private readonly IMapper _mapper;
        public CreateModel(Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult OnGet(string refOrderId)
        {
            if (string.IsNullOrEmpty(refOrderId))
                return Page();

            var r = (from m in _context.tb_报价表.AsNoTracking()
                     join d in _context.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId into ds
                     where m.单号 == refOrderId
                     select new
                     {
                         Main = m,
                         Details = ds
                     }).FirstOrDefault();

            if (r == null)
                return Page();

            vm_Main.报价单 = refOrderId;
            vm_Main.日期 = DateTime.Now;
            vm_Main.交期 = r.Main.交期;
            vm_Main.往来号 = r.Main.往来号;
            vm_Main.往来 = r.Main.往来;

            foreach (var d in r.Details.OrderBy(m => m.RN))
            {
                var x = new vm_销售订单D
                {
                    子单号 = d.子单号,
                    品号 = d.品号,
                    品名 = d.品名,
                    别名 = d.别名,
                    型号 = d.型号,
                    品牌 = d.品牌,
                    个数 = d.个数,
                    单价 = d.单价,
                    单位 = d.单位,
                    金额 = d.金额,
                    规格 = d.规格,
                    备注 = d.备注,
                    税率 = d.税率,
                    数量 = d.数量,
                    库存 = d.库存,
                };
                vm_Details.Add(x);
            }

            return Page();
        }

        [BindProperty]
        public vm_销售订单 vm_Main { get; set; } = new vm_销售订单();
        [BindProperty]
        public IList<vm_销售订单D> vm_Details { get; set; } = new List<vm_销售订单D>();

        public _CRUD_Template_Model templateModel { get; set; } = new _CRUD_Template_Model();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var remote = _context.funcNewRecord<vm_销售订单, tb_订单表>(vm_Main, BeforeNew: creating =>
            {
                creating.单号 = _context.funcAutoCode("订单号");
                creating.业务类型 = "销售订单";
                creating.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == vm_Main.往来号)?.简称;
            });
            if (await _context.SaveChangesAsync() > 0)
            {
                foreach (var localD in vm_Details)
                {
                    _context.funcNewDetail<vm_销售订单, vm_销售订单D, tb_订单表, tb_订单表D>(remote, localD, BeforeNewD: beforeD =>
                    {
                        if (string.IsNullOrEmpty(beforeD.子单号))
                            beforeD.子单号 = _context.funcAutoCode("子单号");
                        else
                        {
                            var 报价D = _context.tb_报价表D.FirstOrDefault(d => d.子单号 == beforeD.子单号);
                            if (报价D != null)
                                报价D.状态 = "已下单";
                        }
                    });
                }
                await _context.SaveChangesAsync();
            }
            else
                return NotFound();

            #region OldWay
            //Common.ModelHelper.CompleteMainOnCreate(vm_销售订单);
            //vm_销售订单.单号 = _context.funcAutoCode("订单号");
            //vm_销售订单.业务类型 = "销售订单";
            //vm_销售订单.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == vm_销售订单.往来号)?.简称;
            //var tb_订单 = _mapper.Map<tb_订单表>(vm_销售订单);
            //_context.tb_订单表.Add(tb_订单);
            //if (_context.SaveChanges() > 0)
            //{
            //    foreach (var item in vm_销售订单D列表)
            //    {
            //        Common.ModelHelper.CompleteDetailOnCreate(tb_订单, item);
            //        if (string.IsNullOrEmpty(item.子单号))
            //            item.子单号 = _context.funcAutoCode("子单号");
            //        else
            //        {
            //            var remoteD = _context.tb_报价表D.FirstOrDefault(d => d.子单号 == item.子单号);
            //            if (remoteD != null)
            //                remoteD.状态 = "已下单";
            //        }
            //    }
            //    _context.tb_订单表D.AddRange(_mapper.Map<IList<tb_订单表D>>(vm_销售订单D列表));
            //    await _context.SaveChangesAsync();
            //}
            //else
            //    return NotFound();
            #endregion

            return RedirectToPage("./Index");
        }
    }
}