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
    public class DetailsModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;

        public DetailsModel(Pinhua2.Data.Pinhua2Context context)
        {
            _context = context;
        }

        public sys字典表 sys字典表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            sys字典表 = await _context.sys字典表.FirstOrDefaultAsync(m => m.RecordId == id);

            if (sys字典表 == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
