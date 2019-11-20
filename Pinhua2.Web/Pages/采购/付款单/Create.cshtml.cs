using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pinhua2.Data;
using Pinhua2.Data.Models;

namespace Pinhua2.Web.Pages.采购.付款单
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
        public tb_收付表 tb_收付表 { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tb_收付表.Add(tb_收付表);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}