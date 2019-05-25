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
