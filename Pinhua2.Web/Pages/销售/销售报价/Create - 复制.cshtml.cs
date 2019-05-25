using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pinhua2.Data;
using Pinhua2.Data.Extensions;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.销售.销售报价
{
    public class CreateModel2 : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;
        private readonly IMapper _mapper;
        public CreateModel2(Pinhua2.Data.Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public vm_销售报价 vm_销售报价 { get; set; }
        [BindProperty]
        public IList<vm_销售报价D> vm_销售报价D列表 { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Common.ModelHelper.CompleteMainOnCreate(vm_销售报价);
            vm_销售报价.单号 = _context.funcAutoCode("订单号");
            vm_销售报价.业务类型 = "销售报价";
            _context.tb_报价表.Add(_mapper.Map<tb_报价表>(vm_销售报价));
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}