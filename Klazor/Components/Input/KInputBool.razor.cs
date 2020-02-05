using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Linq.Expressions;
using System.Globalization;

namespace Klazor
{
    public partial class KInputBool<TValue> : KInputBase<TValue>
    {
        protected override string FormatValueAsString(TValue value)
        {
            // Avoiding a cast to IFormattable to avoid boxing.
            switch (value)
            {
                case null:
                    return "否";

                case bool @bool:
                    return @bool ? "是" : "否";

                case string @string:

                    if (@string == "是" || @string.ToUpper() == "YES" || @string == "√")
                        return "是";
                    else if (@string == "否" || @string.ToUpper() == "NO" || @string == "×")
                        return "否";
                    else
                        throw new InvalidOperationException($"Unsupported string value");

                default:
                    throw new InvalidOperationException($"Unsupported type {value.GetType()}");
            }
        }
    }
}
