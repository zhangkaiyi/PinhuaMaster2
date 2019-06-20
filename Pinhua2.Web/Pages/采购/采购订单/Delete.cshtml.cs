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

namespace Pinhua2.Web.Pages.采购.采购订单
{
    public class DeleteModel : MyPageModel
    {
        public DeleteModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper) : base(context, mapper)
        {
        }

        [BindProperty]
        public vm_采购订单 Record { get; set; }
        [BindProperty]
        public IList<vm_采购订单D> RecordDs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = _mapper.Map<vm_采购订单>(await _pinhua2.tb_订单表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
            {
                return NotFound();
            }

            RecordDs = await _mapper.ProjectTo<vm_采购订单D>(_pinhua2.tb_订单表D.Where(m => m.RecordId == id)).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tb_订单表 = await _pinhua2.tb_订单表.FindAsync(id);

            if (tb_订单表 != null)
            {
                _pinhua2.tb_订单表.Remove(tb_订单表);
                await _pinhua2.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
