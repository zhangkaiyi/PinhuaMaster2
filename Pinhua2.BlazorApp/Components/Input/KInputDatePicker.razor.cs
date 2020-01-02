using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.DataAnnotations;
using System.Linq.Expressions;
using Pinhua2.ViewModels;
using NodaTime;
using System.Globalization;

namespace Klazor
{
    public partial class KInputDatePicker : KInputBase<DateTime?>
    {
        [Parameter] public string Format { get; set; }

        protected string currentValueAsString
        {
            get => Formatter(Value);
            set
            {
                if (BindConverter.TryConvertTo<DateTime?>(value, CultureInfo.InvariantCulture, out var result))
                {
                    currentValue = result;
                }
            }
        }

        public override Func<DateTime?, string> Formatter { get; set; }
        protected override void OnInitialized()
        {
            Formatter = dt => dt?.ToString(Format);
        }

        protected bool isMouseOver;
        protected bool isVisible;

        protected void DateChanged(LocalDate localDate)
        {
            isVisible = false;
            currentValue = localDate.ToDateTimeUnspecified();
        }
    }
}
