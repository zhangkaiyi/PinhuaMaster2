﻿using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Klazor
{
    public partial class KPaginationItem : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        protected string Classname =>
        new CssBuilder("page-item")
            .AddClass("active", IsActive)
            .AddClass("disabled", IsDisabled)
            .AddClass(Class)
        .Build();

        [Parameter] public bool IsActive { get; set; }
        [Parameter] public bool IsDisabled { get; set; }
        [Parameter] public string Class { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
