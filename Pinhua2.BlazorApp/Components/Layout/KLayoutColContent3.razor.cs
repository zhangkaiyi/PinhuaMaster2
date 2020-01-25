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
    public partial class KLayoutColContent3 : KComponentBase
    {
        [Parameter] public RenderFragment ColContent1 { get; set; }
        [Parameter] public RenderFragment ColContent2 { get; set; }
        [Parameter] public RenderFragment ColContent3 { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }

    }
}
