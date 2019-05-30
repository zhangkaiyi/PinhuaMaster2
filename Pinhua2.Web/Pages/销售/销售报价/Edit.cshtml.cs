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

            vm_销售报价 = _mapper.Map<vm_销售报价>(await _context.tb_报价表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (vm_销售报价 == null)
            {
                return NotFound();
            }

            vm_销售报价D列表 = await _mapper.ProjectTo<vm_销售报价D>(_context.tb_报价表D.Where(m => m.RecordId == id)).ToListAsync();
            vm_销售报价D列表 = (from d in _context.tb_报价表D.AsNoTracking()
                        join prod in _context.tb_商品表.AsNoTracking() on d.品号 equals prod.品号
                        where d.RecordId == vm_销售报价.RecordId
                        select new vm_销售报价D
                        {
                            Guid = d.Guid,
                            RecordId = d.RecordId,
                            品号 = d.品号,
                            Idx = d.Idx,
                            RN = d.RN,
                            Sequence = d.Sequence,
                            个数 = d.个数,
                            别名 = d.别名,
                            单价 = d.单价,
                            单位 = d.单位,
                            品名 = d.品名,
                            品牌 = d.品牌,
                            型号 = d.型号,
                            备注 = d.备注,
                            子单号 = d.子单号,
                            库存 = d.库存,
                            数量 = d.数量,
                            状态 = d.状态,
                            税率 = d.税率,
                            规格 = d.规格,
                            宽度 = prod.宽度,
                            金额 = d.金额,
                            长度 = prod.长度,
                            面厚 = prod.面厚,
                            高度 = prod.高度,
                            上次价=d.上次价,
                            上次日期=d.上次日期,                            
                        }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var remote = _context.tb_报价表.FirstOrDefault(m => m.RecordId == vm_销售报价.RecordId);
            if (remote == null)
                return NotFound();

            // 非空字段赋值给跟踪实体
            vm_销售报价.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == vm_销售报价.往来号)?.简称;
            _mapper.Map<vm_销售报价, tb_报价表>(vm_销售报价, remote);

            var remoteDetails = _context.tb_报价表D.Where(d => d.RecordId == remote.RecordId);

            // 数据库中的子单号与新明细中没有相同的，则从数据库中删除
            foreach (var remoteD in remoteDetails)
            {
                if (!vm_销售报价D列表.Where(p => !string.IsNullOrEmpty(p.子单号)).Any(p => p.子单号 == remoteD.子单号))
                    _context.tb_报价表D.Remove(remoteD);
            }
            // 新明细中的子单号为空，则添加
            foreach (var localD in vm_销售报价D列表.Where(p => string.IsNullOrEmpty(p.子单号)))
            {
                Common.ModelHelper.CompleteDetailOnUpdate(remote, localD);
                localD.子单号 = _context.funcAutoCode("子单号");
                _context.tb_报价表D.Add(_mapper.Map<tb_报价表D>(localD));
            }
            // 子单号相同，则赋值
            foreach (var localD in vm_销售报价D列表.Where(p => !string.IsNullOrEmpty(p.子单号)))
            {
                foreach (var remoteD in remoteDetails)
                {
                    if (remoteD.子单号 == localD.子单号)
                    {
                        _mapper.Map<vm_销售报价D, tb_报价表D>(localD, remoteD);
                        break;
                    }
                }
            }
            //_context.tb_报价表D.AddRange(_mapper.Map<IList<tb_报价表D>>(vm_销售报价D列表));
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool tb_报价表Exists(int id)
        {
            return _context.tb_报价表.Any(e => e.RecordId == id);
        }
    }
}
