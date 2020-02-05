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
    public partial class KInputDropdown: KInputBase<string>
    {
        [Parameter] public IEnumerable<string> Items { get; set; }
    }
}
