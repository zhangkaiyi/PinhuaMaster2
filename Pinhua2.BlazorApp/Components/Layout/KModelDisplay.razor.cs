using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;

namespace Klazor
{
    public partial class KModelDisplay : ComponentBase
    {
        protected string Classname => new CssBuilder("")
            .AddClass(Class)
            .Build();
        protected ElementReference Me { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public string Class { get; set; }

        //[Inject] protected Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; }

        protected override void OnInitialized()
        {

        }
    }
}
