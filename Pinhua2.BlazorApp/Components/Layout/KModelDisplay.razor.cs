using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;

namespace Klazor
{
    public partial class KModelDisplay : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }

        [Parameter] public object DataSource { get; set; } = new object();

        protected List<MyMarkModel> myMarkModels;

        //[Inject] protected Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; }

        protected override void OnInitialized()
        {

        }

        protected override void OnParametersSet()
        {
            myMarkModels = MyMark.Parse(DataSource).ToList();
        }
    }
}
