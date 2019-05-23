using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;

namespace Pinhua2.Web.Pages.销售.销售报价
{
    public class IndexModel : PageModel
    {
        private readonly Pinhua2.Data.Pinhua2Context _context;

        public IndexModel(Pinhua2.Data.Pinhua2Context context)
        {
            _context = context;
        }

        public IList<tb_报价表> tb_报价表 { get;set; }

        public async Task OnGetAsync()
        {
            tb_报价表 = await _context.tb_报价表.ToListAsync();
        }
    }
}
