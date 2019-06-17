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
using Pinhua2.Web.Common;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.采购.采购订单
{
    public class IndexModel : MyPageModel
    {
        public IndexModel(Pinhua2Context pinhua2, IMapper mapper) : base(pinhua2, mapper)
        {

        }

        public IList<vm_采购订单> Records { get; set; }

        public async Task OnGetAsync()
        {
            Records = await _mapper.ProjectTo<vm_采购订单>(_pinhua2.tb_订单表).ToListAsync();
        }
    }
}
