using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Pinhua2.Web.Common;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.主数据.字典
{
    public class DeleteModel : MyPageModel
    {
        public DeleteModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper):base(context,mapper)
        {
            
        }

        public vm_字典 字典 { get; set; }
        public IList<vm_字典D> 字典D列表 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            字典 = _mapper.Map<vm_字典>(await _pinhua2.tb_字典表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (字典 == null)
            {
                return NotFound();
            }

            字典D列表 = _mapper.ProjectTo<vm_字典D>(_pinhua2.tb_字典表D.Where(d => d.RecordId == id)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sys字典表 = await _pinhua2.tb_字典表.FindAsync(id);

            if (sys字典表 != null)
            {
                var 字典列表 = _pinhua2.tb_字典表.Where(p=>p.RecordId==sys字典表.RecordId);
                var 字典明细列表 = _pinhua2.tb_字典表D.Where(p => p.RecordId == sys字典表.RecordId);
                _pinhua2.tb_字典表.RemoveRange(字典列表);
                _pinhua2.tb_字典表D.RemoveRange(字典明细列表);
                await _pinhua2.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
