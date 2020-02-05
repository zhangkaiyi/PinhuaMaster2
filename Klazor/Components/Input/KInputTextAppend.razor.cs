using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace Klazor
{
    public partial class KInputTextAppend : KInputBase<string>
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
