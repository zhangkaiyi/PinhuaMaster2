using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Extensions;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.销售.销售报价
{
    public class CreateModel : PageModel
    {
        private readonly Pinhua2Context _context;
        private readonly IMapper _mapper;
        public CreateModel(Pinhua2Context context, IMapper mapper)
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

        public IList<SelectListItem> CustomerSelectList
        {
            get
            {
                var customers = _context.tb_往来表.AsNoTracking().Where(c => c.类型 == "客户");

                var customerSelectList = new List<SelectListItem>();

                customerSelectList.Add(new SelectListItem
                {
                    Text = "无",
                    Value = "",
                });
                foreach (var customer in customers)
                {
                    customerSelectList.Add(new SelectListItem
                    {
                        Text = customer.往来号 + " - " + customer.简称,
                        Value = customer.往来号
                    });
                }
                return customerSelectList;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Common.ModelHelper.CompleteMainOnCreate(vm_销售报价);
            vm_销售报价.单号 = _context.funcAutoCode("订单号");
            vm_销售报价.业务类型 = "销售报价";
            vm_销售报价.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == vm_销售报价.往来号)?.简称;
            var tb_报价 = _mapper.Map<tb_报价表>(vm_销售报价);
            _context.tb_报价表.Add(tb_报价);
            if (_context.SaveChanges() > 0)
            {
                foreach (var item in vm_销售报价D列表)
                {
                    Common.ModelHelper.CompleteDetailOnCreate(tb_报价, item);
                    item.子单号 = _context.funcAutoCode("子单号");
                }
                _context.tb_报价表D.AddRange(_mapper.Map<IList<tb_报价表D>>(vm_销售报价D列表));
                await _context.SaveChangesAsync();
            }
            else
                return NotFound();

            return RedirectToPage("./Index");
        }
    }
}