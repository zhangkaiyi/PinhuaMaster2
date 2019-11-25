using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Common.Attributes;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.ViewComponents
{
    public class SelectForCompanyModel
    {
        public CustomDisplayModel Model { get; set; }

        public IList<SelectListItem> CustomerSelectList { get; set; }

        public bool Disabled { get; set; }
    }
    public class SelectForCompany : ViewComponent
    {
        private readonly Pinhua2Context _context;


        public SelectForCompany(Pinhua2Context pinhua2)
        {
            _context = pinhua2;
        }

        public IViewComponentResult Invoke(CustomDisplayModel model, bool disabled = false)
        {
            var viewModel = new SelectForCompanyModel
            {
                Model = model,
                Disabled = disabled,
                CustomerSelectList = _context.SelectList_客户()
            };
            return View(viewModel);
        }
    }
}
