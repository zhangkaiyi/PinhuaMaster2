using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.主数据.字典
{
    public class EditModel : PageModel
    {
        private readonly Pinhua2Context _pinhua2;
        private readonly IMapper _mapper;

        public EditModel(Pinhua2Context pinhua2, IMapper mapper)
        {
            _pinhua2 = pinhua2;
            _mapper = mapper;
        }

        [BindProperty]
        public vm_字典 vm_字典 { get; set; }
        [BindProperty]
        public IList<vm_字典D> vm_字典D列表 { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            vm_字典 = _mapper.Map<vm_字典>(_pinhua2.tb_字典表.FirstOrDefault(m => m.RecordId == id));

            if (vm_字典 == null)
            {
                return NotFound();
            }

            vm_字典D列表 = _mapper.ProjectTo<vm_字典D>(_pinhua2.tb_字典表D.Where(m => m.RecordId == id)).ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //var remote = _pinhua2.tb_字典表.FirstOrDefault(m => m.RecordId == vm_字典.RecordId);
            //if (remote == null)
            //    return NotFound();

            // 非空字段赋值给跟踪实体
            //_mapper.Map<vm_字典, tb_字典表>(vm_字典, remote);

            if (_pinhua2.funcEditRecord<vm_字典, tb_字典表>(vm_字典) == null)
                return NotFound();

            //// 删除旧明细
            //var tb_字典表D列表 = _pinhua2.tb_字典表D.Where(p => p.RecordId == vm_字典.RecordId);
            //_pinhua2.tb_字典表D.RemoveRange(tb_字典表D列表);

            //// 插入新明细
            //foreach (var item in vm_字典D列表)
            //{
            //    Common.ModelHelper.CompleteDetailOnUpdate(remote, item);
            //    item.字典名 = vm_字典.字典名;
            //    item.组 = vm_字典.组;
            //}
            //_pinhua2.tb_字典表D.AddRange(_mapper.Map<IList<tb_字典表D>>(vm_字典D列表));

            _pinhua2.funcEditDetails<vm_字典, vm_字典D, tb_字典表, tb_字典表D>(vm_字典, vm_字典D列表,creatingD=> {
                creatingD.字典名 = vm_字典.字典名;
                creatingD.组 = vm_字典.组;
            });

            // 保存改变
            try
            {
                _pinhua2.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_字典表Exists(vm_字典.RecordId))
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

        private bool tb_字典表Exists(int id)
        {
            return _pinhua2.tb_字典表.Any(e => e.RecordId == id);
        }
    }
}
