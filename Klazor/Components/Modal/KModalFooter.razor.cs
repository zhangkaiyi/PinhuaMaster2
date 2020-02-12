using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klazor
{
    public partial class KModalFooter : ComponentBase
    {
        protected string Classname => new CssBuilder("modal-footer")
            .AddClass(Class)
            .Build();
        protected ElementReference Me { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public string Class { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<KModal> OnOK { get; set; }
        [Parameter] public EventCallback<KModal> OnCancel { get; set; }
        [Parameter] public string OKText { get; set; } = "确定";
        [Parameter] public Color OKColor { get; set; } = Color.Primary;
        [Parameter] public string CancelText { get; set; } = "取消";
        [Parameter] public Color CancelColor { get; set; } = Color.Secondary;
        [Parameter] public bool CustomizeFooter { get; set; } = false;
        [CascadingParameter] public KModal Modal { get; set; }

        protected void HandleOK()
        {
            Modal.Hide();
            if (OnOK.HasDelegate)
            {
                OnOK.InvokeAsync(Modal);
            }
        }
        protected void HandleCancel()
        {
            Modal.Hide();
            if (OnCancel.HasDelegate)
            {
                OnCancel.InvokeAsync(Modal);
            }
        }
    }
}
