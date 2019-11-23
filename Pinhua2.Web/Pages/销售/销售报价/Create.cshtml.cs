using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
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
        public vm_销售报价 vm_Main { get; set; } = new vm_销售报价();
        [BindProperty]
        public IList<vm_销售报价D> vm_Details { get; set; } = new List<vm_销售报价D>();
        [BindProperty]
        public _CRUD_Template_Model templateModel { get; set; } = new _CRUD_Template_Model();

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

        public IList<SelectListItem> UnitSelectList
        {
            get
            {
                var dic = from p in _context.tb_字典表.AsNoTracking()
                          join d in _context.tb_字典表D.AsNoTracking() on p.RecordId equals d.RecordId
                          where p.字典名 == "地板计量单位"
                          select d;

                var unitSelectList = new List<SelectListItem>();

                foreach (var item in dic)
                {
                    unitSelectList.Add(new SelectListItem
                    {
                        Text = item.名称,
                        Value = item.名称
                    });
                }
                return unitSelectList;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Common.ModelHelper.CompleteMainOnCreate(vm_销售报价);
            //vm_销售报价.单号 = _context.funcAutoCode("订单号");
            //vm_销售报价.业务类型 = "销售报价";
            //vm_销售报价.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == vm_销售报价.往来号)?.简称;
            //var tb_报价 = _mapper.Map<tb_报价表>(vm_销售报价);
            //_context.tb_报价表.Add(tb_报价);

            var tb_报价 = _context.funcNewRecord<vm_销售报价, tb_报价表>(vm_Main, before =>
            {
                before.单号 = _context.funcAutoCode("订单号");
                before.业务类型 = "销售报价";
                before.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == vm_Main.往来号)?.简称;
            });
            if (_context.SaveChanges() > 0)
            {
                foreach (var item in vm_Details)
                {
                    _context.funcNewDetail<vm_销售报价, vm_销售报价D, tb_报价表, tb_报价表D>(tb_报价, item, beforeNewD =>
                    {
                        beforeNewD.子单号 = _context.funcAutoCode("子单号");
                    });
                    Common.ModelHelper.CompleteDetailOnCreate(tb_报价, item);
                }
                //_context.tb_报价表D.AddRange(_mapper.Map<IList<tb_报价表D>>(vm_销售报价D列表));
                await _context.SaveChangesAsync();
            }
            else
                return NotFound();

            return RedirectToPage("./Index");
        }
    }
}