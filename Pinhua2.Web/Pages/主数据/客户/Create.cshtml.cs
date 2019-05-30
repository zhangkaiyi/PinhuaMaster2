using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.主数据.客户
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
        public vm_客户 客户 { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Common.ModelHelper.CompleteMainOnCreate(客户);
            //客户.往来号 = _pinhua2.funcAutoCode("往来号");
            //客户.类型 = "客户";
            //_pinhua2.tb_往来表.Add(_mapper.Map<tb_往来表>(客户));

            _pinhua2.funcNewRecord<vm_客户, tb_往来表>(客户, creating => {
                creating.往来号 = _pinhua2.funcAutoCode("往来号");
                creating.类型 = "客户";
            });

            _pinhua2.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}