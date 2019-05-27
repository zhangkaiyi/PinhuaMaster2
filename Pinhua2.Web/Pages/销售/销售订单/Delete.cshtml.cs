using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.销售.销售订单
{
    public class DeleteModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;
        private readonly IMapper _mapper;

        public DeleteModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public vm_销售订单 vm_销售订单 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            vm_销售订单 = _mapper.Map<vm_销售订单>(await _context.tb_订单表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (vm_销售订单 == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tb_订单表 = await _context.tb_订单表.FindAsync(id);
            if (tb_订单表 != null)
            {
                var tb_订单表D = _context.tb_订单表D.Where(p => p.RecordId == tb_订单表.RecordId);
                foreach (var localD in tb_订单表D)
                {
                    foreach (var remoteD in _context.tb_报价表D.Where(p => p.子单号 == localD.子单号))
                    {
                        remoteD.状态 = "";
                    }
                }
                _context.tb_订单表.Remove(tb_订单表);
                _context.tb_订单表D.RemoveRange(tb_订单表D);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
