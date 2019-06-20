using System;
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

namespace Pinhua2.Web.Pages.销售.销售出库单
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
        public vm_销售出库 Record { get; set; }

        [BindProperty]
        public IList<vm_销售出库D> RecordDs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = _mapper.Map<vm_销售出库>(await _context.tb_IO.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
            {
                return NotFound();
            }

            RecordDs = await _mapper.ProjectTo<vm_销售出库D>(_context.tb_IOD.Where(m => m.RecordId == id)).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tb_IO = await _context.tb_IO.FindAsync(id);
            if (tb_IO != null)
            {
                var tb_IOD = _context.tb_IOD.Where(p => p.RecordId == tb_IO.RecordId);
                //foreach (var localD in tb_IOD)
                //{
                //    foreach (var remoteD in _context.tb_报价表D.Where(p => p.子单号 == localD.子单号))
                //    {
                //        remoteD.状态 = "";
                //    }
                //}
                _context.tb_IO.Remove(tb_IO);
                _context.tb_IOD.RemoveRange(tb_IOD);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
