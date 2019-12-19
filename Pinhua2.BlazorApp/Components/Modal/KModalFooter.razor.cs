using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;

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
        [Parameter] public EventCallback<KTableEvent> OnOK { get; set; }
        [CascadingParameter] public KModal Modal { get; set; }
        protected override void OnInitialized()
        {

        }

        protected void OK()
        {
            var KModalEvent = new KTableEvent() { Target = Modal };
            OnOK.InvokeAsync(KModalEvent);
        }
    }
}
