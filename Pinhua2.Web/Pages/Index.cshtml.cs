﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pinhua2.Data;
using Pinhua2.Web.Mapper;

namespace Pinhua2.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Pinhua2Context _pinhua2Context;
        private readonly IStringLocalizer<vm_客户> _localizer;
        public IndexModel(Pinhua2Context pinhua2Context, IStringLocalizer<vm_客户> localizer, IStringLocalizerFactory factory)
        {
            _pinhua2Context = pinhua2Context;
            _localizer = localizer;
        }

        public class Trip
        {
            [Required]
            public string Destination { get; set; }
            public DateTime TravelDate { get; set; }
            public decimal TicketPrice { get; set; }
        }

        [BindProperty]
        public Trip MyTrip { get; set; }

        public IActionResult OnGet()
        {
            _pinhua2Context.Database.Migrate();
            return RedirectToPage("/销售/销售出库单/Index");
        }

        public void OnPost()
        {

        }
    }
}
