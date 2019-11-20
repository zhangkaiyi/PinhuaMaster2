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

namespace Pinhua2.Web.Pages.采购.付款单
{
    public class DeleteModel : MyPageModel
    {
        public DeleteModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public vm_付款单 Record { get; set; }

        public IList<vm_付款单D> RecordDs { get; set; }

        public _CRUD_Template_Model_Index templateModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = _mapper.Map<vm_付款单>(await _context.tb_收付表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
            {
                return NotFound();
            }

            RecordDs = _mapper.ProjectTo<vm_付款单D>(_context.tb_收付表D.Where(m => m.RecordId == id)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tb_收付表 = await _context.tb_收付表.FindAsync(id);

            if (tb_收付表 != null)
            {
                _context.tb_收付表.Remove(tb_收付表);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
