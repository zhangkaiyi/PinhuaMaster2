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
using Pinhua2.Web.Common;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.采购.采购订单
{
    public class CreateModel : MyPageModel
    {
        public CreateModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public vm_采购订单 Record { get; set; }
        [BindProperty]
        public IList<vm_采购订单D> RecordDs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var remote = _pinhua2.funcNewRecord<vm_采购订单, tb_订单表>(Record, creating =>
            {
                creating.单号 = _pinhua2.funcAutoCode("订单号");
                creating.业务类型 = "采购订单";
                creating.往来 = _pinhua2.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == Record.往来号)?.简称;
            });

            if (await _pinhua2.SaveChangesAsync() > 0)
            {
                foreach (var localD in RecordDs)
                {
                    _pinhua2.funcNewDetail<vm_采购订单, vm_采购订单D, tb_订单表, tb_订单表D>(remote, localD, BeforeNewD: beforeD =>
                    {
                        if (string.IsNullOrEmpty(beforeD.子单号))
                            beforeD.子单号 = _pinhua2.funcAutoCode("子单号");
                        else
                        {
                            var 报价D = _pinhua2.tb_报价表D.FirstOrDefault(d => d.子单号 == beforeD.子单号);
                            if (报价D != null)
                                报价D.状态 = "已下单";
                        }
                    });
                }
                await _pinhua2.SaveChangesAsync();
            }
            else
                return NotFound();

            return RedirectToPage("./Index");
        }
    }
}