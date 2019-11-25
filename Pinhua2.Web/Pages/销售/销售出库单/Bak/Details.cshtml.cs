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

namespace Pinhua2.Web.Pages.销售.销售出库单.Bak
{
    public class DetailsModel : PageModel
    {
        private readonly Pinhua2Context _context;
        private readonly IMapper _mapper;
        public DetailsModel(Pinhua2Context context, IMapper mapper)
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

            RecordDs = _mapper.ProjectTo<vm_销售出库D>(_context.tb_IOD.Where(m => m.RecordId == id)).ToList();

            return Page();
        }
    }
}
