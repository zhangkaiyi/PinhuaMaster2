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

namespace Klazor
{
    public partial class KFormGroup : ComponentBase
    {
        protected string labelClassname => new CssBuilder("col-form-label")
            .AddClass("text-left", CascadedContainer?.LabelAlign == LabelAlign.Left)
            .AddClass("text-right", CascadedContainer?.LabelAlign == LabelAlign.Right)
            .AddClass("text-center", CascadedContainer?.LabelAlign == LabelAlign.Center)
            .AddClass($"col-{CascadedContainer?.LabelCol}", CascadedContainer?.LabelCol != null)
            .AddClass($"col-xs-{CascadedContainer?.LabelColXS}", CascadedContainer?.LabelColXS != null)
            .AddClass($"col-sm-{CascadedContainer?.LabelColSM}", CascadedContainer?.LabelColSM != null)
            .AddClass($"col-md-{CascadedContainer?.LabelColMD}", CascadedContainer?.LabelColMD != null)
            .AddClass($"col-lg-{CascadedContainer?.LabelColLG}", CascadedContainer?.LabelColLG != null)
            .AddClass($"col-xl-{CascadedContainer?.LabelColXL}", CascadedContainer?.LabelColXL != null)
            .Build();

        protected string inputClassname => new CssBuilder()
            .AddClass($"col-{12 - CascadedContainer?.LabelCol}", CascadedContainer?.LabelCol != null)
            .AddClass($"col-xs-{12 - CascadedContainer?.LabelColXS}", CascadedContainer?.LabelColXS != null)
            .AddClass($"col-sm-{12 - CascadedContainer?.LabelColSM}", CascadedContainer?.LabelColSM != null)
            .AddClass($"col-md-{12 - CascadedContainer?.LabelColMD}", CascadedContainer?.LabelColMD != null)
            .AddClass($"col-lg-{12 - CascadedContainer?.LabelColLG}", CascadedContainer?.LabelColLG != null)
            .AddClass($"col-xl-{12 - CascadedContainer?.LabelColXL}", CascadedContainer?.LabelColXL != null)
            .Build();

        protected string currentLabel
        {
            get
            {
                return string.IsNullOrEmpty(Label) ? "Default" : Label;
            }
        }

        [CascadingParameter] public KForm CascadedForm { get; set; }
        [CascadingParameter] public KFormGroupContainer CascadedContainer { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public bool IsRequired { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public bool? InputReadonly { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
