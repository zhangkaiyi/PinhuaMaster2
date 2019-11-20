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

namespace Pinhua2.Web.Pages.采购.付款单
{
    public class IndexModel : MyPageModel
    {
        public IndexModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public IList<vm_付款单> Records { get; set; }

        public IList<vm_付款单D> RecordsDs { get; set; }

        public _CRUD_Template_Model_Index templateModel { get; set; }

        public async Task OnGetAsync()
        {
            Records = await _mapper.ProjectTo<vm_付款单>(_pinhua2.tb_收付表)
                .Where(m => m.类型 == "付款").OrderByDescending(m => m.日期).ThenByDescending(m => m.单号).ToListAsync();
            RecordsDs = await _mapper.ProjectTo<vm_付款单D>(_pinhua2.tb_收付表D)
                .Where(m => Records.Any(r => r.RecordId == m.RecordId)).OrderByDescending(m => m.RecordId).ThenBy(m => m.RN).ToListAsync();

            templateModel = new _CRUD_Template_Model_Index
            {
                RecordMains = new _CRUD_Template_Model_Details
                {
                    Title = "付款单",
                    Data = Records.Cast<object>()
                },
                RecordDetailsArray = new List<_CRUD_Template_Model_Details>
                {
                    new _CRUD_Template_Model_Details
                    {
                        Title = "明细",
                        Url = "/api/mm/付款/",
                        Data = RecordsDs
                    },
                },
            };
        }
    }
}
