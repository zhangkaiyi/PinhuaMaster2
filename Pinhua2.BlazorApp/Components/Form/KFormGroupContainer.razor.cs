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
using System.Globalization;
using Microsoft.AspNetCore.Components.Rendering;

namespace Klazor
{
    public partial class KFormGroupContainer : ComponentBase
    {
        [Parameter] public LabelAlign LabelAlign { get; set; }
        [Parameter] public bool? InputReadonly { get; set; }
        [Parameter] public int? LabelCol { get; set; }
        [Parameter] public int? LabelColXS { get; set; }
        [Parameter] public int? LabelColSM { get; set; }
        [Parameter] public int? LabelColMD { get; set; }
        [Parameter] public int? LabelColLG { get; set; }
        [Parameter] public int? LabelColXL { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            // If _fixedEditContext changes, tear down and recreate all descendants.
            // This is so we can safely use the IsFixed optimization on CascadingValue,
            // optimizing for the common case where _fixedEditContext never changes.
            builder.OpenComponent<CascadingValue<KFormGroupContainer>>(0);
            builder.AddAttribute(1, "IsFixed", true);
            builder.AddAttribute(2, "Value", this);
            builder.AddAttribute(3, "ChildContent", ChildContent);
            builder.CloseComponent();
        }

    }
}
