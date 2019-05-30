using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.主数据.商品
{
    public class CreateModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;
        private readonly IMapper _mapper;

        public CreateModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public vm_商品_地板 vm_地板 { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Common.ModelHelper.CompleteMainOnCreate(vm_地板);
            //vm_地板.品号 = _context.funcAutoCode("商品号");
            //_context.tb_商品表.Add(_mapper.Map<tb_商品表>(vm_地板));

            _context.funcNewRecord<vm_商品_地板, tb_商品表>(vm_地板, creating=> {
                creating.品号 = _context.funcAutoCode("商品号");
            });

            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}