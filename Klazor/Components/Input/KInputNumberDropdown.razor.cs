using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace Klazor
{
    public partial class KInputNumberDropdown : KInputNumber<decimal?>
    {
        [Parameter] public IEnumerable<decimal?> Items { get; set; }
    }
}
