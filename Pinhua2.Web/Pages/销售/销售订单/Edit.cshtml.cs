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

namespace Pinhua2.Web.Pages.销售.销售订单
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
        public vm_销售订单 vm_销售订单 { get; set; }
        [BindProperty]
        public IList<vm_销售订单D> vm_销售订单D列表 { get; set; }

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

            vm_销售订单 = _mapper.Map<vm_销售订单>(await _context.tb_订单表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (vm_销售订单 == null)
            {
                return NotFound();
            }

            vm_销售订单D列表 = await _mapper.ProjectTo<vm_销售订单D>(_context.tb_订单表D.Where(m => m.RecordId == id)).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var remote = _context.Set<tb_订单表>().FirstOrDefault(m => m.RecordId == vm_销售订单.RecordId);
            if (remote == null)
                return NotFound();

            // 非空字段赋值给跟踪实体
            vm_销售订单.往来 = _context.Set<tb_往来表>().AsNoTracking().FirstOrDefault(p => p.往来号 == vm_销售订单.往来号)?.简称;
            _mapper.Map<vm_销售订单, tb_订单表>(vm_销售订单, remote);

            var remoteDetails = _context.Set<tb_订单表D>().Where(d => d.RecordId == remote.RecordId).ToList();

            // 数据库中的子单号与新明细中没有相同的，则从数据库中删除
            foreach (var remoteD in remoteDetails)
            {
                if (!vm_销售订单D列表.Any(p => p.子单号 == remoteD.子单号))
                {
                    var tb_报价D = _context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == remoteD.子单号);
                    if (tb_报价D != null)
                        tb_报价D.状态 = "";
                    _context.Remove<tb_订单表D>(remoteD);
                }
            }

            foreach (var localD in vm_销售订单D列表)
            {
                Common.ModelHelper.CompleteDetailOnUpdate(remote, localD);

                if (remoteDetails.Any(d => d.子单号 == localD.子单号)) // 子单号相同的，表示修改
                {
                    var remoteD = _context.Set<tb_订单表D>().FirstOrDefault(m => m.子单号 == localD.子单号);
                    _mapper.Map(localD, remoteD);
                }
                if (!remoteDetails.Any(d => d.子单号 == localD.子单号))
                {
                    if (string.IsNullOrEmpty(localD.子单号)) // 子单号为空的，表示新插入
                    {
                        localD.子单号 = _context.funcAutoCode("子单号");
                        _context.Attach<tb_订单表D>(_mapper.Map<tb_订单表D>(localD)).State = EntityState.Added;
                    }
                    else if (!string.IsNullOrEmpty(localD.子单号)) // 子单号不为空，表示从报价单引入，插入
                    {
                        var baojiaD = _context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == localD.子单号);
                        if (baojiaD != null)
                            baojiaD.状态 = "已下单";
                        _context.Attach<tb_订单表D>(_mapper.Map<tb_订单表D>(localD)).State = EntityState.Added;
                    }
                }
            }

            // 数据库中的子单号与新明细中没有相同的，则从数据库中删除
            // 新明细中的子单号为空，则添加
            // 子单号相同，则赋值

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task UpdateDetails<TSrcDetail, TDst, TDstDetail>(int Id, IList<TSrcDetail> srcDetails)
            where TDst : tb_订单表
            where TDstDetail : tb_订单表D
            where TSrcDetail : vm_销售订单D
        {
            //var remoteDetails = _context.tb_订单表D.Where(d => d.RecordId == Id).ToList();
            var remoteDetails = _context.Set<TDstDetail>().Where(d => (d as _IBaseTableDetail).RecordId == Id).ToList();
            foreach (var remoteD in remoteDetails)
            {
                //if (!vm_销售订单D列表.Any(p => p.子单号 == remoteD.子单号))
                if (!srcDetails.Any(p => p.子单号 == remoteD.子单号))
                {
                    var tb_报价D = _context.tb_报价表D.FirstOrDefault(d => d.子单号 == remoteD.子单号);
                    if (tb_报价D != null)
                        tb_报价D.状态 = "";
                    _context.Attach<tb_订单表D>(remoteD).State = EntityState.Deleted;
                }
            }

            foreach (var localD in vm_销售订单D列表)
            {
                Common.ModelHelper.CompleteDetailOnUpdate(_context.Set<TDst>().AsNoTracking().FirstOrDefault(), localD);

                if (remoteDetails.Any(d => d.子单号 == localD.子单号)) // 子单号相同的，表示修改
                {
                    var remoteD = _context.Set<TDstDetail>().AsNoTracking().FirstOrDefault(m => m.子单号 == localD.子单号);
                    _mapper.Map(localD, remoteD);
                    _context.Attach(remoteD).State = EntityState.Modified;
                }
                if (!remoteDetails.Any(d => d.子单号 == localD.子单号))
                {
                    if (!string.IsNullOrEmpty(localD.子单号)) // 子单号不为空，表示从报价单引入，插入
                    {
                        var baojiaD = _context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == localD.子单号);
                        if (baojiaD != null)
                            baojiaD.状态 = "已下单";
                        _context.Attach(_mapper.Map<tb_订单表D>(localD)).State = EntityState.Added;
                    }
                    else if (string.IsNullOrEmpty(localD.子单号)) // 子单号为空的，表示新插入
                    {
                        localD.子单号 = _context.funcAutoCode("子单号");
                        _context.Attach(_mapper.Map<tb_订单表D>(localD)).State = EntityState.Added;
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        private bool tb_订单表Exists(int id)
        {
            return _context.tb_订单表.Any(e => e.RecordId == id);
        }
    }
}
