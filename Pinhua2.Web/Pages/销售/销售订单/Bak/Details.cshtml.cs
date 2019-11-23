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

namespace Pinhua2.Web.Pages.销售.销售订单.Bak
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

        public vm_销售订单 vm_销售订单 { get; set; }
        public IList<vm_销售订单D> vm_销售订单D列表 { get; set; }

        public _CRUD_Template_Model templateModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            vm_销售订单 = _mapper.Map<vm_销售订单>(await _context.tb_订单表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (vm_销售订单 == null)
            {
                return NotFound();
            }

            vm_销售订单D列表 = await _mapper.ProjectTo<vm_销售订单D>(_context.tb_订单表D.Where(m => m.RecordId == id)).ToListAsync();

            templateModel = new _CRUD_Template_Model
            {
                RecordMain = new _CRUD_Template_Model_Main
                {
                    Title = "销售订单",
                    Data = vm_销售订单,
                },
                RecordDetailsArray = new List<_CRUD_Template_Model_Details>
{
            new _CRUD_Template_Model_Details
            {
                Title="明细",
                Data = vm_销售订单D列表.Cast<object>(),
            },
        }
            };

            return Page();
        }
    }
}
