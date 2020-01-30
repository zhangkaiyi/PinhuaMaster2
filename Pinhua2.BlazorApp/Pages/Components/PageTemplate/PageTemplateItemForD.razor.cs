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
    public partial class PageTemplateItemForD : ComponentBase
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public string CancelTitle { get; set; } = "返回";
        [Parameter] public string DeleteTitle { get; set; } = "确认删除";
        [Parameter] public EventCallback<MouseEventArgs> OnCancel { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnDelete { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
