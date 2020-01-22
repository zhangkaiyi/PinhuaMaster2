using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.主数据.字典
{
    public class CreateModel : PageModel
    {
        private readonly Pinhua2Context _pinhua2;
        private readonly IMapper _mapper;

        public CreateModel(Pinhua2.Data.Pinhua2Context pinhua2, IMapper mapper)
        {
            _pinhua2 = pinhua2;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public vm_字典 vm_字典 { get; set; }
        [BindProperty]
        public IList<vm_字典D> vm_字典D列表 { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var remote = _pinhua2.funcNewRecord<vm_字典, tb_字典表>(vm_字典);

            if (_pinhua2.SaveChanges() > 0)
            {
                // 保存后获取自增主键RecordId
                // 补完明细表，主表字段写入明细表
                foreach (var localD in vm_字典D列表)
                {
                    _pinhua2.funcNewDetail<vm_字典, vm_字典D, tb_字典表, tb_字典表D>(remote, localD, BeforeNewD: beforeD =>
                    {
                        beforeD.字典号 = remote.字典号;
                        beforeD.组号 = remote.组号;
                    });
                }
                // 再次保存
                _pinhua2.SaveChanges();
            }
            else
                return NotFound();

            #region comment
            //// 补完字段
            //Common.ModelHelper.CompleteMainOnCreate(vm_字典);
            //// 映射为实体类型
            //var tb_字典 = _mapper.Map<tb_字典表>(vm_字典);
            //// 插入
            //_pinhua2.tb_字典表.Add(tb_字典);
            //// 保存
            //if (_pinhua2.SaveChanges() > 0)
            //{
            //    // 保存后获取自增主键RecordId
            //    // 补完明细表，主表字段写入明细表
            //    foreach (var item in vm_字典D列表)
            //    {
            //        Common.ModelHelper.CompleteDetailOnCreate(tb_字典, item);
            //        item.字典名 = vm_字典.字典名;
            //        item.组 = vm_字典.组;
            //    }
            //    // 插入明细表
            //    _pinhua2.tb_字典表D.AddRange(_mapper.Map<IList<tb_字典表D>>(vm_字典D列表));
            //    // 再次保存
            //    _pinhua2.SaveChanges();
            //}
            //else
            //    return NotFound();
            #endregion

            return RedirectToPage("./Index");
        }
    }
}