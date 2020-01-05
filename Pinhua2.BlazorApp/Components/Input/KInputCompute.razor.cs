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
using System.Globalization;

namespace Klazor
{
    public partial class KInputCompute<TValue> : KInputNumber<TValue>
    {
        protected bool hasSet = false;

        [Parameter] public TValue ComputedValue { get; set; }

        protected override void OnParametersSet()
        {
            if(FormatValueAsString(ComputedValue) != currentValueAsString)
            //if (!ComputedValue.Equals(currentValue))
            {
                if (BindConverter.TryConvertTo<TValue>(FormatValueAsString(ComputedValue), CultureInfo.CurrentCulture, out var result))
                {
                    currentValue = result;
                    ValueChanged.InvokeAsync(result);
                }
            }
        }
    }
}
