using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.主数据.供应商
{
    public class EditModel : PageModel
    {
        private readonly Pinhua2Context _context;
        private readonly IMapper _mapper;

        public EditModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public vm_供应商 供应商 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 往来单位 = await _context.tb_往来表.FirstOrDefaultAsync(m => m.RecordId == id);

            if (往来单位 == null)
            {
                return NotFound();
            }

            供应商 = _mapper.Map<vm_供应商>(往来单位);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var 往来单位 = _mapper.Map<tb_往来表>(供应商);
            _context.Attach(往来单位).State = EntityState.Modified;

            _context.funcEditRecord<vm_供应商, tb_往来表>(供应商, updating=> {
                updating.类型 = "供应商";
            });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sys往来表Exists(供应商.RecordId))
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
            return _context.tb_往来表.Any(e => e.RecordId == id);
        }
    }
}
