using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Linq.Expressions;
using NodaTime;
using System.Globalization;

namespace Klazor
{
    public partial class KInputDatePicker : KInputBase<DateTime?>
    {
        [Parameter] public string Format { get; set; }
        [Parameter] public bool EnablePicker { get; set; } = true;

        protected override string FormatValueAsString(DateTime? value)
        {
            // Avoiding a cast to IFormattable to avoid boxing.
            return BindConverter.FormatValue(value, Format, CultureInfo.InvariantCulture);
        }

        protected override void OnInitialized()
        {
            
        }

        protected bool isMouseOver;
        protected bool isVisible;

        protected void Selected(LocalDate localDate)
        {
            isVisible = false;
            currentValue = localDate.ToDateTimeUnspecified();
        }
    }
}
