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
    public class IndexModel : MyPageModel
    {
        public IndexModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public IList<vm_采购申请> Records { get; set; }

        public IList<vm_采购申请D> RecordsDs { get; set; }

        public _CRUD_Template_Model_Index templateModel { get; set; }

        public async Task OnGetAsync()
        {
            Records = await _mapper.ProjectTo<vm_采购申请>(_pinhua2.tb_需求表)
                .Where(m => m.业务类型 == "采购申请").OrderByDescending(m => m.交期).ThenByDescending(m => m.单号).ToListAsync();
            RecordsDs = await _mapper.ProjectTo<vm_采购申请D>(_pinhua2.tb_需求表D)
                .Where(m => Records.Any(r => r.RecordId == m.RecordId)).OrderByDescending(m => m.RecordId).ThenBy(m => m.RN).ToListAsync();

            templateModel = new _CRUD_Template_Model_Index
            {
                RecordMains = new _CRUD_Template_Model_Details
                {
                    Title = "采购申请",
                    Data = Records.Cast<object>()
                },
                RecordDetailsArray = new List<_CRUD_Template_Model_Details>
                {
                    new _CRUD_Template_Model_Details
                    {
                        Title = "明细",
                        Url = "/api/mm/申请/",
                        Data = RecordsDs
                    },
                },
            };
        }
    }
}
