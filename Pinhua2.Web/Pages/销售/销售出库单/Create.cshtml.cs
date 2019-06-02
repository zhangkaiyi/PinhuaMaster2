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
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.销售.销售出库单
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
        public vm_销售出库 Record { get; set; }
        [BindProperty]
        public IList<vm_销售出库D> RecordDs { get; set; }

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

            var remote = _context.funcNewRecord<vm_销售出库, tb_IO>(Record, creating =>
                 {
                     creating.类型 = "销售出库";
                     creating.单号 = _context.funcAutoCode("订单号");
                     creating.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == Record.往来号)?.简称;
                 });
            if (await _context.SaveChangesAsync() > 0)
            {
                foreach (var localD in RecordDs)
                {
                    _context.funcNewDetails<vm_销售出库, vm_销售出库D, tb_IO, tb_IOD>(remote, localD, creatingD=> {
                        creatingD.RecordId = remote.RecordId;
                    });
                }
                await _context.SaveChangesAsync();
            }
            else
                return NotFound();

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}