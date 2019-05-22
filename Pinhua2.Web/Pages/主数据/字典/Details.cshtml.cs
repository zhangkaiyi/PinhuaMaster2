using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.主数据.字典
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

        public vm_字典 字典 { get; set; }
        public IList<vm_字典D> 字典D列表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            字典 = _mapper.Map<vm_字典>(await _context.tb_字典表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (字典 == null)
            {
                return NotFound();
            }

            字典D列表 = _mapper.ProjectTo<vm_字典D>(_context.tb_字典表D.Where(d => d.RecordId == id)).ToList();

            return Page();
        }
    }
}
