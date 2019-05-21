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
        public dto字典 字典 { get; set; }
        [BindProperty]
        public IList<dto字典Detail> 字典D { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            字典 = _mapper.Map<dto字典>(await _pinhua2.sys字典表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (字典 == null)
            {
                return NotFound();
            }

            字典D = _mapper.ProjectTo<dto字典Detail>(_pinhua2.sys字典表_D.Where(m => m.RecordId == id)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var sys字典表 = _mapper.Map<sys字典表>(字典);
            _pinhua2.Attach(sys字典表).State = EntityState.Modified;
            var toRemove = _pinhua2.sys字典表_D.Where(p => p.RecordId == 字典.RecordId);
            _pinhua2.sys字典表_D.RemoveRange(toRemove);
            foreach (var item in 字典D)
            {
                item.RecordId = 字典.RecordId;
            }
            _pinhua2.sys字典表_D.AddRange(_mapper.Map<IList<sys字典表_D>>(字典D));
            try
            {
                await _pinhua2.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sys字典表Exists(sys字典表.RecordId))
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

        private bool sys字典表Exists(int id)
        {
            return _pinhua2.sys字典表.Any(e => e.RecordId == id);
        }
    }
}
