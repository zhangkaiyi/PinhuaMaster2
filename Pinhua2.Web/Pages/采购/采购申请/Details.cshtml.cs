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

namespace Pinhua2.Web.Pages.采购.采购申请
{
    public class DetailsModel : MyPageModel
    {
        public DetailsModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper) : base(context, mapper)
        {
        }

        [BindProperty]
        public vm_采购申请 Record { get; set; }
        [BindProperty]
        public IList<vm_采购申请D> RecordDs { get; set; }

        public _CRUD_Template_Model templateModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = _mapper.Map<vm_采购申请>(await _pinhua2.tb_需求表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
            {
                return NotFound();
            }

            RecordDs = await _mapper.ProjectTo<vm_采购申请D>(_pinhua2.tb_需求表D.Where(m => m.RecordId == id)).ToListAsync();

            templateModel = new _CRUD_Template_Model
            {
                RecordMain = new _CRUD_Template_Model_Main
                {
                    Title = "采购申请",
                    Data = Record,
                },
                RecordDetailsArray = new List<_CRUD_Template_Model_Details>{
                    new _CRUD_Template_Model_Details{
                        Title = "明细",
                        Data = RecordDs,
                    },
                }
            };

            return Page();
        }
    }
}
