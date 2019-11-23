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
    public class IndexModel : PageModel
    {
        private readonly Pinhua2Context _context;
        private readonly IMapper _mapper;

        public IndexModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<vm_销售报价> vm_Mains { get; set; }
        public IList<vm_销售报价D> vm_Details { get; set; }

        public _CRUD_Template_Model_Index templateModel { get; set; }

        public async Task OnGetAsync()
        {
            vm_Mains = await _mapper.ProjectTo<vm_销售报价>(_context.tb_报价表)
                                    .Where(m => m.业务类型 == "销售报价")
                                    .OrderByDescending(m => m.交期)
                                    .ThenByDescending(m => m.单号)
                                    .ToListAsync();
        }
    }
}
