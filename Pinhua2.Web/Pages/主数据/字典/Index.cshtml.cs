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
    public class IndexModel : PageModel
    {
        private readonly Pinhua2Context _pinhua2;
        private readonly IMapper _mapper;

        public IndexModel(Pinhua2Context pinhua2, IMapper mapper)
        {
            _pinhua2 = pinhua2;
            _mapper = mapper;
        }

        public IList<vm_字典> 字典列表 { get; set; }

        public void OnGet()
        {
            字典列表 = _mapper.ProjectTo<vm_字典>(_pinhua2.tb_字典表).ToList();
        }
    }
}
