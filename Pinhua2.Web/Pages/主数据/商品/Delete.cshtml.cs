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

namespace Pinhua2.Web.Pages.主数据.商品
{
    public class DeleteModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;
        private readonly IMapper _mapper;

        public DeleteModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public vm_商品_地板 vm_地板 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            vm_地板 = _mapper.Map<vm_商品_地板>(await _context.tb_商品表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (vm_地板 == null)
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

            var tb_商品 = await _context.tb_商品表.FindAsync(id);

            if (tb_商品 != null)
            {
                _context.tb_商品表.Remove(tb_商品);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
