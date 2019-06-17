using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;

namespace Pinhua2.Web.Pages.采购.采购订单
{
    public class DeleteModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;

        public DeleteModel(Pinhua2.Data.Pinhua2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public tb_订单表 tb_订单表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tb_订单表 = await _context.tb_订单表.FirstOrDefaultAsync(m => m.RecordId == id);

            if (tb_订单表 == null)
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

            tb_订单表 = await _context.tb_订单表.FindAsync(id);

            if (tb_订单表 != null)
            {
                _context.tb_订单表.Remove(tb_订单表);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
