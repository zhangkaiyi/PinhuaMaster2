﻿using System;
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

namespace Pinhua2.Web.Pages.销售.收款单
{
    public class DeleteModel : PageModel
    {
        private readonly Pinhua2Context _context;
        private readonly IMapper _mapper;

        public DeleteModel(Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public vm_收款单 Record { get; set; }
        [BindProperty]
        public IList<vm_收款单D> RecordDs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = _mapper.Map<vm_收款单>(await _context.tb_收付表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
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
            var tb_收付 = await _context.tb_收付表.FindAsync(id);

            if (Record != null)
            {
                _context.tb_收付表.Remove(tb_收付);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
