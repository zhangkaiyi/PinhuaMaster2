using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;

namespace Pinhua2.Web.Pages.采购.采购询价
{
    public class EditModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;

        public EditModel(Pinhua2.Data.Pinhua2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public tb_报价表 tb_报价表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tb_报价表 = await _context.tb_报价表.FirstOrDefaultAsync(m => m.RecordId == id);

            if (tb_报价表 == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(tb_报价表).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_报价表Exists(tb_报价表.RecordId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool tb_报价表Exists(int id)
        {
            return _context.tb_报价表.Any(e => e.RecordId == id);
        }
    }
}
