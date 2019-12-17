using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;

namespace Klazor
{
    public partial class KModalBody : ComponentBase
    {
        protected string Classname => new CssBuilder("modal-body")
            .AddClass(Class)
            .Build();
        protected ElementReference Me { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public string Class { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        protected override void OnInitialized()
        {

        }

    }
}
