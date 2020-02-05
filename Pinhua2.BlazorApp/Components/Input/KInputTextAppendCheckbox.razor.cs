using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.DataAnnotations;
using System.Linq.Expressions;
using Pinhua2.ViewModels;

namespace Klazor
{
    public partial class KInputTextAppendCheckbox : KInputBase<string>
    {
        [Parameter] public bool Checked { get; set; }
        [Parameter] public string Label { get; set; } = "选择";
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
