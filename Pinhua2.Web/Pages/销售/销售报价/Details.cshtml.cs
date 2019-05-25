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

namespace Pinhua2.Web.Pages.销售.销售报价
{
    public class DetailsModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;
        private readonly IMapper _mapper;

        public DetailsModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public vm_销售报价 vm_销售报价 { get; set; }
        public IList<vm_销售报价D> vm_销售报价D列表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            vm_销售报价 = _mapper.Map<vm_销售报价>(await _context.tb_报价表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (vm_销售报价 == null)
            {
                return NotFound();
            }

            vm_销售报价D列表 = await _mapper.ProjectTo<vm_销售报价D>(_context.tb_报价表D.Where(m => m.RecordId == id)).ToListAsync();

            return Page();
        }
    }
}
