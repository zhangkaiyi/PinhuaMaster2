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

namespace Pinhua2.Web.Pages.主数据.供应商
{
    public class EditModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;

        public EditModel(Pinhua2.Data.Pinhua2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public sys往来表 sys往来表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            sys往来表 = await _context.sys往来表.FirstOrDefaultAsync(m => m.RecordId == id);

            if (sys往来表 == null)
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

            _context.Attach(sys往来表).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sys往来表Exists(sys往来表.RecordId))
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

        private bool sys往来表Exists(int id)
        {
            return _context.sys往来表.Any(e => e.RecordId == id);
        }
    }
}
