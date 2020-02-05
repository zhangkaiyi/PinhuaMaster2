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
    public partial class KInputNumber<TValue> : KInputBase<TValue>
    {
        protected override string FormatValueAsString(TValue value)
        {
            // Avoiding a cast to IFormattable to avoid boxing.
            switch (value)
            {
                case null:
                    return null;

                case int @int:
                    return BindConverter.FormatValue(@int, CultureInfo.InvariantCulture);

                case long @long:
                    return BindConverter.FormatValue(@long, CultureInfo.InvariantCulture);

                case float @float:
                    return BindConverter.FormatValue(@float, CultureInfo.InvariantCulture);

                case double @double:
                    return BindConverter.FormatValue(@double, CultureInfo.InvariantCulture);

                case decimal @decimal:
                    var result = BindConverter.FormatValue(@decimal, CultureInfo.InvariantCulture).Split('.');
                    if (string.IsNullOrEmpty(result.ElementAtOrDefault(1)?.TrimEnd('0')))
                        return result[0];
                    else
                        return string.Join('.', result[0], result[1]?.TrimEnd('0'));
                    //return BindConverter.FormatValue(@decimal, CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.');

                default:
                    throw new InvalidOperationException($"Unsupported type {value.GetType()}");
            }
        }
    }
}
