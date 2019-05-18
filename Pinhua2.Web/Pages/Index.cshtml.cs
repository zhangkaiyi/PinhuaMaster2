using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Extensions;

namespace Pinhua2.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Pinhua2Context _pinhua2Context;
        public IndexModel(Pinhua2Context pinhua2Context)
        {
            _pinhua2Context = pinhua2Context;
        }
        public void OnGet()
        {
            _pinhua2Context.Database.Migrate();
        }

        public void OnPost()
        {

        }
    }
}
