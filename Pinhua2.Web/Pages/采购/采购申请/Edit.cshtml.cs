﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;

namespace Pinhua2.Web.Pages.采购.采购申请
{
    public class EditModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;

        public EditModel(Pinhua2.Data.Pinhua2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public tb_需求表 tb_需求表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tb_需求表 = await _context.tb_需求表.FirstOrDefaultAsync(m => m.RecordId == id);

            if (tb_需求表 == null)
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

            _context.Attach(tb_需求表).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_需求表Exists(tb_需求表.RecordId))
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

        private bool tb_需求表Exists(int id)
        {
            return _context.tb_需求表.Any(e => e.RecordId == id);
        }
    }
}
