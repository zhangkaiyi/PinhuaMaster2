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
        public vm_收款单 vm_Main { get; set; }
        [BindProperty]
        public IList<vm_收款单D> vm_Details { get; set; }

        public _CRUD_Template_Model templateModel { get; set; } = new _CRUD_Template_Model();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            vm_Main = _mapper.Map<vm_收款单>(await _context.tb_收付表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (vm_Main == null)
            {
                return NotFound();
            }

            vm_Details = _mapper.ProjectTo<vm_收款单D>(_context.tb_收付表D.Where(m => m.RecordId == id)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tb_收付 = await _context.tb_收付表.FindAsync(id);

            if (tb_收付 != null)
            {
                var tb_收付D = _context.tb_收付表D.Where(p => p.RecordId == tb_收付.RecordId);
                _context.tb_收付表.Remove(tb_收付);
                _context.tb_收付表D.RemoveRange(tb_收付D);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
