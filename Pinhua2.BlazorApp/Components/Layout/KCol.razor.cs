using BlazorComponentUtilities;
using Klazor.Util.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Klazor
{
    public partial class KCol : ColumnBase
    {
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }

        protected string Classname =>
        new CssBuilder()
            .AddClass(GetColumnClass())
            .AddClass(Class)
        .Build();

        [Parameter] public string Class { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
