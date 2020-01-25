using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;

namespace Klazor
{
    public partial class KLayoutContentItem : KComponentBase
    {
        [CascadingParameter] public KLayoutContent Parent { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Toolbar { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public int? Size { get; set; } = 12;
    }
}
