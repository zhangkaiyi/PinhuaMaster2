using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data.Models;
using Pinhua2.Web.Common;
using Pinhua2.Web.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Pages.采购.采购订单
{
    public class DetailsModel : MyPageModel
    {
        public DetailsModel(Pinhua2.Data.Pinhua2Context context, IMapper mapper):base(context, mapper)
        {
        }

        public vm_采购订单 Record { get; set; }
        public IList<vm_采购订单D> RecordDs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = _mapper.Map<vm_采购订单>(await _pinhua2.tb_订单表.FirstOrDefaultAsync(m => m.RecordId == id));

            if (Record == null)
            {
                return NotFound();
            }

            RecordDs = await _mapper.ProjectTo<vm_采购订单D>(_pinhua2.tb_订单表D.Where(m => m.RecordId == id)).ToListAsync();

            return Page();
        }
    }
}
