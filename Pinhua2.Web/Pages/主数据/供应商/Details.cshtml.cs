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

namespace Pinhua2.Web.Pages.主数据.供应商
{
    public class DetailsModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _pinhua2;
        private readonly IMapper _mapper;

        public DetailsModel(Pinhua2.Data.Pinhua2Context pinhua2, IMapper mapper)
        {
            _pinhua2 = pinhua2;
            _mapper=mapper;
        }

        public dto供应商 供应商 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 往来单位 = await _pinhua2.sys往来表.FirstOrDefaultAsync(m => m.RecordId == id);

            if (往来单位 == null)
            {
                return NotFound();
            }

            供应商 = _mapper.Map<dto供应商>(往来单位);

            return Page();
        }
    }
}
