﻿using System;
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

namespace Pinhua2.Web.Pages.销售.收款单
{
    public class CreateModel : PageModel
    {
        private readonly Pinhua2Context _context;
        private readonly IMapper _mapper;

        public CreateModel(Pinhua2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public vm_收款单 vm_Main { get; set; } = new vm_收款单();
        [BindProperty]
        public IList<vm_收款单D> vm_Details { get; set; } = new List<vm_收款单D>();
        [BindProperty]
        public _CRUD_Template_Model templateModel { get; set; } = new _CRUD_Template_Model();

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

        public IActionResult OnGet(string companyId, string refOrderId, string type)
        {
            vm_Main.往来号 = companyId;
            vm_Main.关联单号 = refOrderId;
            vm_Main.小类 = type;
            vm_Main.类型 = "收款";

            var set = _context.list_收付待收(vm_Main.往来号);
            if (string.IsNullOrEmpty(refOrderId))
            {
                foreach (var item in set)
                {
                    vm_Details.Add(_mapper.Map<vm_收款单D>(item));
                }
            }
            else
            {
                foreach (var item in set.Where(m => m.单号 == refOrderId))
                {
                    vm_Details.Add(_mapper.Map<vm_收款单D>(item));
                }
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var remote = _context.funcNewRecord<vm_收款单, tb_收付表>(vm_Main, creating =>
            {
                creating.单号 = _context.funcAutoCode("订单号");
                creating.类型 = "收款";
                creating.往来 = _context.tb_往来表.AsNoTracking().FirstOrDefault(p => p.往来号 == vm_Main.往来号)?.简称;
            });

            if (await _context.SaveChangesAsync() > 0)
            {
                foreach (var localD in vm_Details)
                {
                    _context.funcNewDetail<vm_收款单, vm_收款单D, tb_收付表, tb_收付表D>(remote, localD, BeforeNewD: beforeD =>
                    {
                        if (string.IsNullOrEmpty(beforeD.子单号))
                            beforeD.子单号 = _context.funcAutoCode("子单号");
                        else
                        {
                            //var 报价D = _context.tb_报价表D.FirstOrDefault(d => d.子单号 == beforeD.子单号);
                            //if (报价D != null)
                            //    报价D.状态 = "已下单";
                        }
                    });
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}