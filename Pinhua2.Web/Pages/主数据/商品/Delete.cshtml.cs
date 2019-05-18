using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;

namespace Pinhua2.Web.Pages.主数据.商品
{
    public class DeleteModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;

        public DeleteModel(Pinhua2.Data.Pinhua2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public sys商品表 sys商品表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            sys商品表 = await _context.sys商品表.FirstOrDefaultAsync(m => m.RecordId == id);

            if (sys商品表 == null)
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

            sys商品表 = await _context.sys商品表.FindAsync(id);

            if (sys商品表 != null)
            {
                _context.sys商品表.Remove(sys商品表);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
