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

        public CustomDisplayModel cdm { get; set; }

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

        public IViewComponentResult Invoke(CustomDisplayModel model, bool disabled = false)
        {
            var viewModel = new SelectForCompanyModel
            {
                Model = model,
                Disabled = disabled,
                CustomerSelectList = CustomerSelectList
            };
            return View(viewModel);
        }
    }
}
