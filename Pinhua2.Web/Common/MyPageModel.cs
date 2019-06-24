using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Common
{
    public class MyPageModel : PageModel
    {
        protected readonly Pinhua2Context _pinhua2;
        protected readonly Pinhua2Context _context;
        protected readonly IMapper _mapper;
        public MyPageModel(Pinhua2Context pinhua2, IMapper mapper) : base()
        {
            _pinhua2 = pinhua2;
            _context = pinhua2;
            _mapper = mapper;
        }
    }
}
