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

namespace Pinhua2.Web.Pages.主数据.商品
{
    public class EditModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;
        private readonly IMapper _mapper;

        public EditModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var tb_商品 = _context.tb_商品表.FirstOrDefault(m => m.RecordId == vm_地板.RecordId);
            //_mapper.Map<vm_商品_地板, tb_商品表>(vm_地板, tb_商品);
            //Common.ModelHelper.CompleteMainOnEdit(tb_商品);

            _context.funcEditRecord<vm_商品_地板, tb_商品表>(vm_地板);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sys商品表Exists(vm_地板.RecordId))
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

        private bool sys商品表Exists(int id)
        {
            return _context.tb_商品表.Any(e => e.RecordId == id);
        }
    }
}
