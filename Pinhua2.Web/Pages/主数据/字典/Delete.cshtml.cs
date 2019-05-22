using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;

namespace Pinhua2.Web.Pages.主数据.字典
{
    public class DeleteModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;

        public DeleteModel(Pinhua2.Data.Pinhua2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public tb_字典表 sys字典表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            sys字典表 = await _context.tb_字典表.FirstOrDefaultAsync(m => m.RecordId == id);

            if (sys字典表 == null)
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

            sys字典表 = await _context.tb_字典表.FindAsync(id);

            if (sys字典表 != null)
            {
                var 字典列表 = _context.tb_字典表.Where(p=>p.RecordId==sys字典表.RecordId);
                var 字典明细列表 = _context.tb_字典表D.Where(p => p.RecordId == sys字典表.RecordId);
                _context.tb_字典表.RemoveRange(字典列表);
                _context.tb_字典表D.RemoveRange(字典明细列表);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
