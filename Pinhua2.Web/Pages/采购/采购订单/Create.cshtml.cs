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
using Pinhua2.Web.Common;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.采购.采购订单
{
    public class CreateModel : MyPageModel
    {
        public CreateModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public vm_采购订单 Record { get; set; }

        public IList<SelectListItem> SupplierSelectList
        {
            get
            {
                var customers = _pinhua2.tb_往来表.AsNoTracking().Where(c => c.类型 == "供应商");

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _pinhua2.funcNewRecord<vm_采购订单, tb_订单表>(Record);
            await _pinhua2.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}