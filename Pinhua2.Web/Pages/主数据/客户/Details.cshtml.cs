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

namespace Pinhua2.Web.Pages.主数据.客户
{
    public class DetailsModel : PageModel
    {
        private readonly Pinhua2Context _pinhua2;
        private readonly IMapper _mapper;

        public DetailsModel(Pinhua2.Data.Pinhua2Context pinhua2, IMapper mapper)
        {
            _pinhua2 = pinhua2;
            _mapper = mapper;
        }

        public vm_客户 客户 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            客户 = _mapper.Map<vm_客户>(await _pinhua2.tb_往来表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (客户 == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
