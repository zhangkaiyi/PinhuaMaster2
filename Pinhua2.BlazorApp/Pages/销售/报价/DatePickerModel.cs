using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Pinhua2.BlazorApp.Pages.Models
{
    public class DatePickerModel
    {
        public bool Visible { get; set; } = false;
        public bool IsMouseOver { get; set; } = false;
        public string Date { get; set; } = string.Empty;
    }
}
