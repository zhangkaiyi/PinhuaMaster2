using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Pinhua2.Data;
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
        public vm_销售订单 Record { get; set; }
        [BindProperty]
        public IList<vm_销售订单D> RecordDs { get; set; }

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

            Record = _mapper.Map<vm_销售订单>(await _context.tb_订单表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
            {
                return NotFound();
            }

            RecordDs = (from d in _context.tb_订单表D.AsNoTracking()
                        join prod in _context.tb_商品表.AsNoTracking() on d.品号 equals prod.品号
                        where d.RecordId == Record.RecordId
                        select new vm_销售订单D
                        {
                            RecordId = d.RecordId,
                            品号 = d.品号,
                            Idx = d.Idx,
                            RN = d.RN,
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
                            新价日期 = d.新价日期,
                            最新价 = d.最新价,
                            状态 = d.状态,
                            税率 = d.税率,
                            规格 = d.规格,
                            宽度 = prod.宽度,
                            质保 = d.质保,
                            金额 = d.金额,
                            长度 = prod.长度,
                            面厚 = prod.面厚,
                            高度 = prod.高度
                        }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPost2Async()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var remote = _context.Set<tb_订单表>().FirstOrDefault(m => m.RecordId == Record.RecordId);
            if (remote == null)
                return NotFound();

            // 非空字段赋值给跟踪实体
            Record.往来 = _context.Set<tb_往来表>().AsNoTracking().FirstOrDefault(p => p.往来号 == Record.往来号)?.简称;
            _mapper.Map<vm_销售订单, tb_订单表>(Record, remote);

            var remoteDetails = _context.Set<tb_订单表D>().Where(d => d.RecordId == remote.RecordId).ToList();

            // 数据库中的子单号与新明细中没有相同的，则从数据库中删除
            foreach (var remoteD in remoteDetails)
            {
                if (!RecordDs.Any(p => p.子单号 == remoteD.子单号))
                {
                    var tb_报价D = _context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == remoteD.子单号);
                    if (tb_报价D != null)
                        tb_报价D.状态 = "";
                    _context.Remove<tb_订单表D>(remoteD);
                }
            }

            foreach (var localD in RecordDs)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var remote = _context.funcEditRecord<vm_销售订单, tb_订单表>(Record, BeforeNew: before =>
            {
                // 非空字段赋值给跟踪实体
                before.业务类型 = "销售订单";
                before.往来 = _context.Set<tb_往来表>().FirstOrDefault(p => p.往来号 == Record.往来号)?.简称;
            });

            _context.funcEditDetails<vm_销售订单, vm_销售订单D, tb_订单表, tb_订单表D>(Record, RecordDs,
                creatingD =>
            {
                if (string.IsNullOrEmpty(creatingD.子单号)) // 子单号为空的，表示新插入
                {
                    creatingD.子单号 = _context.funcAutoCode("子单号");
                }
                else if (!string.IsNullOrEmpty(creatingD.子单号)) // 子单号不为空，表示从报价单引入，插入
                {
                    var baojiaD = _context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == creatingD.子单号);
                    if (baojiaD != null)
                        baojiaD.状态 = "已下单";
                }
            },
                updatingD =>
            {
                var baojiaD = _context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == updatingD.子单号);
                if (baojiaD != null)
                    baojiaD.状态 = "已下单";
            },
               deletingD =>
               {
                   var tb_报价D = _context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == deletingD.子单号);
                   if (tb_报价D != null)
                       tb_报价D.状态 = "";
               });

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.funcEditRecord<vm_销售订单, tb_订单表>(vm_销售订单);

            //UpdateOrder<vm_销售订单, vm_销售订单D, tb_订单表, tb_订单表D>(vm_销售订单, vm_销售订单D列表,
            //    DoBeforeRemove: (src, srcD, dst, dstD) =>
            //{
            //    var tb_报价D = _context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == dstD.子单号);
            //    if (tb_报价D != null)
            //        tb_报价D.状态 = "";
            //}, DoBeforeAdd: (src, srcD, dst, dstD) =>
            //{
            //    srcD.子单号 = _context.funcAutoCode("子单号");
            //});

            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }

        private IActionResult UpdateOrder<TLocal, TLocalD, TRemote, TRemoteD>(TLocal local, IList<TLocalD> localDetails,
            Action<TLocal, TLocalD, TRemote, TRemoteD> DoBeforeRemove = null,
            Action<TLocal, TLocalD, TRemote, TRemoteD> DoBeforeAdd = null)
            where TRemote : _BaseTableMain
            where TRemoteD : _BaseTableDetail
            where TLocal : _BaseTableMain
            where TLocalD : _BaseTableDetail
        {
            var remote = _context.Set<TRemote>().FirstOrDefault(m => m.RecordId == local.RecordId);
            if (remote == null)
                return NotFound();

            // 非空字段赋值给跟踪实体
            //vm_销售订单.往来 = _context.Set<tb_往来表>().AsNoTracking().FirstOrDefault(p => p.往来号 == vm_销售订单.往来号)?.简称;
            _mapper.Map<TLocal, TRemote>(local, remote);

            var remoteDetails = _context.Set<TRemoteD>().Where(d => d.RecordId == remote.RecordId).ToList();

            // 数据库中的子单号与新明细中没有相同的，则从数据库中删除
            foreach (var remoteD in remoteDetails)
            {
                if (!localDetails.Any(p => p.子单号 == remoteD.子单号))
                {
                    DoBeforeRemove?.Invoke(local, null, null, remoteD);
                    _context.Remove<TRemoteD>(remoteD);
                }
            }

            foreach (var localD in localDetails)
            {
                Common.ModelHelper.CompleteDetailOnUpdate(remote, localD);

                if (remoteDetails.Any(d => d.子单号 == localD.子单号)) // 子单号相同的，表示修改
                {
                    var remoteD = _context.Set<TRemoteD>().FirstOrDefault(m => m.子单号 == localD.子单号);
                    _mapper.Map(localD, remoteD);
                }
                if (!remoteDetails.Any(d => d.子单号 == localD.子单号))
                {
                    if (string.IsNullOrEmpty(localD.子单号)) // 子单号为空的，表示新插入
                    {
                        DoBeforeAdd?.Invoke(local, localD, null, null);
                        //localD.子单号 = _context.funcAutoCode("子单号");
                        _context.Attach<TRemoteD>(_mapper.Map<TRemoteD>(localD)).State = EntityState.Added;
                    }
                    else if (!string.IsNullOrEmpty(localD.子单号)) // 子单号不为空，表示从报价单引入，插入
                    {
                        var baojiaD = _context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == localD.子单号);
                        if (baojiaD != null)
                            baojiaD.状态 = "已下单";
                        _context.Attach<TRemoteD>(_mapper.Map<TRemoteD>(localD)).State = EntityState.Added;
                    }
                }
            }

            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private bool RecordExists<TDst>(int id) where TDst : _BaseTableMain
        {
            return _context.Set<TDst>().Any(e => e.RecordId == id);
        }
    }
}
