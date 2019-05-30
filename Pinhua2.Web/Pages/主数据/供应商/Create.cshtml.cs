using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.主数据.供应商
{
    public class CreateModel : PageModel
    {
        private readonly Pinhua2Context _pinhua2;
        private readonly IMapper _mapper;

        public CreateModel(Pinhua2.Data.Pinhua2Context pinhua2, IMapper mapper)
        {
            _pinhua2 = pinhua2;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public vm_供应商 供应商 { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _pinhua2.funcNewRecord<vm_供应商, tb_往来表>(供应商, BeforeNew: local =>
            {
                local.往来号 = _pinhua2.funcAutoCode("往来号");
                local.类型 = "供应商";
            });
            _pinhua2.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}