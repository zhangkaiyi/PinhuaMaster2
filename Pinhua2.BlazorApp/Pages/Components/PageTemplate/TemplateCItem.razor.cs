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
using Pinhua2.ViewModels;
using Klazor;
using Microsoft.AspNetCore.Components.Web;

namespace Piuhua2.Components.PageTemplate
{
    public partial class TemplateCItem : ComponentBase
    {
        [CascadingParameter] public TemplateA Parent { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment Toolbar { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string InsertButtonTitle { get; set; } = "添加";
        [Parameter] public EventCallback<MouseEventArgs> InsertButtonOnClick { get; set; }
        [Parameter] public string CancelButtonTitle { get; set; } = "取消";
        [Parameter] public EventCallback<MouseEventArgs> CancelButtonOnClick { get; set; }
        [Parameter] public string SubmitButtonTitle { get; set; } = "确定";
    }
}
