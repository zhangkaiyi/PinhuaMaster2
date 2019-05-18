using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pinhua2.Data;
using Pinhua2.Data.Models;

namespace Pinhua2.Web.Pages.主数据.字典
{
    public class CreateModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;

        public CreateModel(Pinhua2.Data.Pinhua2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public sys字典表 sys字典表 { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.sys字典表.Add(sys字典表);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}