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
        public vm_销售出库 vm_Main { get; set; }
        [BindProperty]
        public IList<vm_销售出库D> vm_Details { get; set; }

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

            vm_Main = _mapper.Map<vm_销售出库>(await _context.tb_IO.FirstOrDefaultAsync(m => m.RecordId == id));

            if (vm_Main == null)
            {
                return NotFound();
            }

            vm_Details = _mapper.ProjectTo<vm_销售出库D>(_context.tb_IOD.Where(m => m.RecordId == id)).ToList();
            vm_Details = (from d in _context.tb_IOD.AsNoTracking()
                          join prod in _context.tb_商品表.AsNoTracking() on d.品号 equals prod.品号
                          where d.RecordId == vm_Main.RecordId
                          select new vm_销售出库D
                          {
                              RecordId = d.RecordId,
                              品号 = d.品号,
                              Idx = d.Idx,
                              RN = d.RN,
                              个数 = d.发,
                              单价 = d.单价,
                              单位 = d.单位,
                              品名 = d.品名,
                              品牌 = d.品牌,
                              备注 = d.备注,
                              子单号 = d.子单号,
                              库存 = d.库存,
                              税率 = d.税率,
                              规格 = d.规格,
                              宽度 = prod.宽度,
                              金额 = d.金额,
                              长度 = prod.长度,
                              面厚 = prod.面厚,
                              高度 = prod.高度,
                              仓 = d.仓,
                              已完数 = d.已完数,
                              库位 = d.库位,
                              批次 = d.批次,
                              条码 = d.条码,
                              计划数 = d.计划数,
                              质保 = d.质保
                          }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var remote = _context.funcEditRecord<vm_销售出库, tb_IO>(vm_Main, BeforeNew: before =>
            {
                // 非空字段赋值给跟踪实体
                before.类型 = "销售出库";
                before.往来 = _context.Set<tb_往来表>().FirstOrDefault(p => p.往来号 == vm_Main.往来号)?.简称;
            });

            _context.funcEditDetails<vm_销售出库, vm_销售出库D, tb_IO, tb_IOD>(vm_Main, vm_Details,
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
