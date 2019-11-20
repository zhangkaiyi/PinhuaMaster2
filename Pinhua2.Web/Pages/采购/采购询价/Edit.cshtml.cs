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
using Pinhua2.Web.Common;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.采购.采购询价
{
    public class EditModel : MyPageModel
    {
        public EditModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper) : base(context, mapper)
        {

        }

        [BindProperty]
        public vm_采购询价 Record { get; set; }
        [BindProperty]
        public IList<vm_采购询价D> RecordDs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = _mapper.Map<vm_采购询价>(await _context.tb_报价表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
            {
                return NotFound();
            }

            RecordDs = (from d in _context.tb_报价表D.AsNoTracking()
                        join prod in _context.tb_商品表.AsNoTracking() on d.品号 equals prod.品号
                        where d.RecordId == Record.RecordId
                        select new vm_采购询价D
                        {
                            RecordId = d.RecordId,
                            品号 = d.品号,
                            Idx = d.Idx,
                            RN = d.RN,
                            个数 = d.个数,
                            别名 = prod.别名,
                            单价 = d.单价,
                            单位 = d.单位,
                            品名 = prod.品名,
                            品牌 = d.品牌,
                            型号 = prod.型号,
                            备注 = d.备注,
                            子单号 = d.子单号,
                            库存 = d.库存,
                            数量 = d.数量,
                            状态 = d.状态,
                            税率 = d.税率,
                            规格 = prod.规格,
                            宽度 = prod.宽度,
                            金额 = d.金额,
                            长度 = prod.长度,
                            面厚 = prod.面厚,
                            高度 = prod.高度
                        }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var remote = _context.funcEditRecord<vm_采购询价, tb_报价表>(Record, BeforeNew: before =>
            {
                // 非空字段赋值给跟踪实体
                before.业务类型 = "采购询价";
                before.往来 = _context.Set<tb_往来表>().FirstOrDefault(p => p.往来号 == Record.往来号)?.简称;
            });

            _context.funcEditDetails<vm_采购询价, vm_采购询价D, tb_报价表, tb_报价表D>(Record, RecordDs,
                creatingD =>
                {
                    if (string.IsNullOrEmpty(creatingD.子单号)) // 子单号为空的，表示新插入
                    {
                        creatingD.子单号 = _context.funcAutoCode("子单号");
                    }
                },
                updatingD =>
                {

                },
               deletingD =>
               {

               });

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
