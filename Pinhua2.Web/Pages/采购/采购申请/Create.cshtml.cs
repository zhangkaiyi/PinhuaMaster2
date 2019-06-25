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
using Pinhua2.Web.Common;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages.采购.采购申请
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
        public vm_采购申请 Record { get; set; }
        [BindProperty]
        public IList<vm_采购申请D> RecordDs { get; set; }

        public _CRUD_Template_Model_Index templateModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var remote = _pinhua2.funcNewRecord<vm_采购申请, tb_需求表>(Record, creating =>
            {
                creating.单号 = _pinhua2.funcAutoCode("订单号");
                creating.业务类型 = "采购申请";
            });

            if (await _pinhua2.SaveChangesAsync() > 0)
            {
                foreach (var localD in RecordDs)
                {
                    _pinhua2.funcNewDetail<vm_采购申请, vm_采购申请D, tb_需求表, tb_需求表D>(remote, localD, BeforeNewD: beforeD =>
                    {
                        if (string.IsNullOrEmpty(beforeD.子单号))
                            beforeD.子单号 = _pinhua2.funcAutoCode("子单号");
                    });
                }
                await _pinhua2.SaveChangesAsync();
            }
            else
                return NotFound();

            return RedirectToPage("./Index");
        }
    }
}