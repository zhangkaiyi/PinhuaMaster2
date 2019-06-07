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

namespace Pinhua2.Web.Pages.销售.收款单
{
    public class EditModel : PageModel
    {
        private readonly Pinhua2Context _context;
        private readonly IMapper _mapper;

        public EditModel(Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public vm_收款单 Record { get; set; }
        [BindProperty]
        public IList<vm_收款单D> RecordDs { get; set; }

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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = _mapper.Map<vm_收款单>(await _context.tb_收付表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
            {
                return NotFound();
            }

            RecordDs = await _mapper.ProjectTo<vm_收款单D>(_context.tb_收付表D.Where(m => m.RecordId == id)).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var remote = _context.funcEditRecord<vm_收款单, tb_收付表>(Record, before=> {
                before.类型 = "收款";
                before.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == Record.往来号)?.简称;
            });
            _context.funcEditDetails<vm_收款单, vm_收款单D, tb_收付表, tb_收付表D>(Record, RecordDs,
                creatingD =>
                {
                    if (string.IsNullOrEmpty(creatingD.子单号)) // 子单号为空的，表示新插入
                    {
                        creatingD.子单号 = _context.funcAutoCode("子单号");
                    }
                    else if (!string.IsNullOrEmpty(creatingD.子单号)) // 子单号不为空，表示从报价单引入，插入
                    {

                    }
                },
                updatingD =>
                {

                },
               deletingD =>
               {

               });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_收付表Exists(Record.RecordId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool tb_收付表Exists(int id)
        {
            return _context.tb_收付表.Any(e => e.RecordId == id);
        }
    }
}
