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

namespace Pinhua2.Web.Pages.采购.采购询价
{
    public class CreateModel : MyPageModel
    {
        public CreateModel(Pinhua2Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public vm_采购询价 Record { get; set; }
        [BindProperty]
        public IList<vm_采购询价D> RecordDs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var remote = _context.funcNewRecord<vm_采购询价, tb_报价表>(Record, before =>
            {
                before.单号 = _context.funcAutoCode("订单号");
                before.业务类型 = "采购询价";
                before.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == Record.往来号)?.简称;
            });
            if (_context.SaveChanges() > 0)
            {
                foreach (var localD in RecordDs)
                {
                    _context.funcNewDetail<vm_采购询价, vm_采购询价D, tb_报价表, tb_报价表D>(remote, localD, beforeNewD =>
                    {
                        beforeNewD.子单号 = _context.funcAutoCode("子单号");
                    });
                }
                await _context.SaveChangesAsync();
            }
            else
                return NotFound();

            return RedirectToPage("./Index");
        }
    }
}