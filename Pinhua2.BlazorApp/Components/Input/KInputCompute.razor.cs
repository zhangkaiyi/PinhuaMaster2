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

namespace Klazor
{
    public partial class KInputCompute<TValue> : KInputBase<TValue>
    {
        [Parameter] public TValue ComputedValue { get; set; }

        protected override void OnParametersSet()
        {
            if (!ComputedValue.Equals(currentValue))
            {
                currentValue = ComputedValue;
                ValueChanged.InvokeAsync(Value);
            }
        }
    }
}
