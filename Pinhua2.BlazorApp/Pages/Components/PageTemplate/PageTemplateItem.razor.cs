using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.DataAnnotations;
using System.Linq.Expressions;
using Pinhua2.ViewModels;
using Klazor;
using Microsoft.AspNetCore.Components.Web;

namespace Piuhua2.Components.PageTemplate
{
    public partial class PageTemplateItem : ComponentBase
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment TopRightContent { get; set; }
        [Parameter] public RenderFragment BottomLeftContent { get; set; }
        [Parameter] public RenderFragment BottomRightContent { get; set; }

        [Parameter] public bool HasTopRightButton { get; set; }
        [Parameter] public string TopRightButtonTitle { get; set; } = "新建";
        [Parameter] public Color TopRightButtonColor { get; set; } = Color.Primary;
        [Parameter] public EventCallback<MouseEventArgs> TopRightButtonOnClick { get; set; }

        [Parameter] public bool HasBottomLeftButton { get; set; }
        [Parameter] public string BottomLeftButtonTitle { get; set; } = "取消";
        [Parameter] public Color BottomLeftButtonColor { get; set; } = Color.Secondary;
        [Parameter] public EventCallback<MouseEventArgs> BottomLeftButtonOnClick { get; set; }

        [Parameter] public bool HasBottomRightButton { get; set; }
        [Parameter] public bool BottomRightButtonSubmit { get; set; }
        [Parameter] public string BottomRightButtonTitle { get; set; } = "确定";
        [Parameter] public Color BottomRightButtonColor { get; set; } = Color.Success;
        [Parameter] public EventCallback<MouseEventArgs> BottomRightButtonOnClick { get; set; }
    }
}
