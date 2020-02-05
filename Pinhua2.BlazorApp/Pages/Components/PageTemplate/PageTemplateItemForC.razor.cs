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
    public partial class PageTemplateItemForC : ComponentBase
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public string AddTitle { get; set; } = "添加";
        [Parameter] public string CancelTitle { get; set; } = "取消";
        [Parameter] public string SaveTitle { get; set; } = "保存";
        [Parameter] public EventCallback<MouseEventArgs> OnAdd { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnCancel { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnSave { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public bool CustomizeTopRight { get; set; }
        [Parameter] public RenderFragment TopRight { get; set; }
    }
}
