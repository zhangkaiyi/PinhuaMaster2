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
    public partial class KInputSelect<TValue>: KInputBase<TValue>
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
