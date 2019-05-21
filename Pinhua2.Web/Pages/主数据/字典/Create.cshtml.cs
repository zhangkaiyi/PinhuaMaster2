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
        public dto字典 字典 { get; set; }
        [BindProperty]
        public IList<dto字典Detail> 字典D { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            字典.创建日 = DateTime.Now;
            字典.创建人 = "张凯译";

            var toAdd = _mapper.Map<sys字典表>(字典);
            _pinhua2.sys字典表.Add(toAdd);

            if (_pinhua2.SaveChanges() > 0)
            {
                foreach (var item in 字典D)
                {
                    item.RecordId = toAdd.RecordId;
                }
                _pinhua2.sys字典表_D.AddRange(_mapper.Map<IList<sys字典表_D>>(字典D));
                _pinhua2.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}