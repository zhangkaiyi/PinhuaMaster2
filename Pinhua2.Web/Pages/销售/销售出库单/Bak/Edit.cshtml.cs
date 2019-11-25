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

namespace Pinhua2.Web.Pages.销售.销售出库单.Bak
{
    public class EditModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;
        private readonly IMapper _mapper;
        public EditModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

                //unitSelectList.Add(new SelectListItem
                //{
                //    Text = "无",
                //    Value = "",
                //});
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

            Record = _mapper.Map<vm_销售出库>(await _context.tb_IO.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
            {
                return NotFound();
            }

            RecordDs = _mapper.ProjectTo<vm_销售出库D>(_context.tb_IOD.Where(m => m.RecordId == id)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var remote = _context.funcEditRecord<vm_销售出库, tb_IO>(Record, BeforeNew: before =>
            {
                // 非空字段赋值给跟踪实体
                before.类型 = "销售出库";
                before.往来 = _context.Set<tb_往来表>().FirstOrDefault(p => p.往来号 == Record.往来号)?.简称;
            });

            _context.funcEditDetails<vm_销售出库, vm_销售出库D, tb_IO, tb_IOD>(Record, RecordDs,
                creatingD =>
                {
                    if (string.IsNullOrEmpty(creatingD.子单号)) // 子单号为空的，表示新插入
                    {
                        creatingD.子单号 = _context.funcAutoCode("子单号");
                    }
                    else if (!string.IsNullOrEmpty(creatingD.子单号)) // 子单号不为空，表示从报价单引入，插入
                    {
                        var baojiaD = _context.Set<tb_订单表D>().FirstOrDefault(d => d.子单号 == creatingD.子单号);
                        if (baojiaD != null)
                            baojiaD.状态 = "已出库";
                    }
                },
                updatingD =>
                {
                    var baojiaD = _context.Set<tb_订单表D>().FirstOrDefault(d => d.子单号 == updatingD.子单号);
                    if (baojiaD != null)
                        baojiaD.状态 = "已出库";
                },
               deletingD =>
               {
                   var tb_报价D = _context.Set<tb_订单表D>().FirstOrDefault(d => d.子单号 == deletingD.子单号);
                   if (tb_报价D != null)
                       tb_报价D.状态 = "";
               });

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool tb_IOExists(int id)
        {
            return _context.tb_IO.Any(e => e.RecordId == id);
        }
    }
}
