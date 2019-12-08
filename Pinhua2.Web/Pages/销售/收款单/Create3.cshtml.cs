using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Common.Attributes;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.销售.收款单
{
    public class vm_收款单_Create3 : Mapper.vm_收款单
    {
        [MyPriority(Priority.High)]
        [Required]
        [CustomDisplay(25, ForIndex = false)]
        [MyViewComponent("SelectForCompany")]
        override public string 往来号 { get; set; } 
    }

    public class vm_收款单D_Create3 : Mapper.vm_收款单D
    {
        
    }

    public class Create3Model : PageModel
    {
        private readonly Pinhua2Context _context;
        private readonly IMapper _mapper;

        public Create3Model(Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public vm_收款单_Create3 vm_Main { get; set; } = new vm_收款单_Create3();
        [BindProperty]
        public IList<vm_收款单D> vm_Details { get; set; } = new List<vm_收款单D>();
        [BindProperty]
        public _CRUD_Template_Model templateModel { get; set; } = new _CRUD_Template_Model();

        public IActionResult OnGet()
        {
            vm_Main.类型 = "收款222";

            var records = _context.tb_收付表D.ToList();

            foreach (var item in records)
            {
                vm_Details.Add(_mapper.Map<tb_收付表D,vm_收款单D>(item));
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var remote = _context.funcNewRecord<vm_收款单, tb_收付表>(vm_Main, creating =>
            {
                creating.单号 = _context.funcAutoCode("订单号");
                creating.类型 = "收款";
                creating.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == vm_Main.往来号)?.简称;
            });

            if (await _context.SaveChangesAsync() > 0)
            {
                foreach (var localD in vm_Details)
                {
                    _context.funcNewDetail<vm_收款单, vm_收款单D, tb_收付表, tb_收付表D>(remote, localD, BeforeNewD: beforeD =>
                    {
                        if (string.IsNullOrEmpty(beforeD.子单号))
                            beforeD.子单号 = _context.funcAutoCode("子单号");
                        else
                        {
                            //var 报价D = _context.tb_报价表D.FirstOrDefault(d => d.子单号 == beforeD.子单号);
                            //if (报价D != null)
                            //    报价D.状态 = "已下单";
                        }
                    });
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}