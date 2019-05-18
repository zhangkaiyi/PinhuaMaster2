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

namespace Pinhua2.Web.Pages.主数据.客户
{
    public class EditModel : PageModel
    {
        private readonly Pinhua2Context _pinhua2;
        private readonly IMapper _mapper;

        public EditModel(Pinhua2.Data.Pinhua2Context pinhua2, IMapper mapper)
        {
            _pinhua2 = pinhua2;
            _mapper = mapper;
        }

        [BindProperty]
        public dto客户 客户 { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            客户 = _mapper.Map<dto客户>(_pinhua2.sys往来表.FirstOrDefault(m => m.RecordId == id));

            if (客户 == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var 往来表 = _mapper.Map<sys往来表>(客户);
            _pinhua2.Attach(往来表).State = EntityState.Modified;

            try
            {
                _pinhua2.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sys往来表Exists(客户.RecordId))
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

        private bool sys往来表Exists(int id)
        {
            return _pinhua2.sys往来表.Any(e => e.RecordId == id);
        }
    }
}
