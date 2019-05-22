using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Pinhua2.Web.Pages.主数据.客户
{
    public class IndexModel : PageModel
    {
        private readonly Pinhua2Context _pinhua2;
        private readonly IMapper _mapper;

        public IndexModel(Pinhua2.Data.Pinhua2Context pinhua2, IMapper mapper)
        {
            _pinhua2 = pinhua2;
            _mapper = mapper;
        }

        public IList<vm_客户> 客户列表 { get; set; }

        public void OnGet()
        {
            客户列表 = _mapper.ProjectTo<vm_客户>(_pinhua2.tb_往来表.Where(p => p.类型 == "客户")).ToList();
        }
    }
}
