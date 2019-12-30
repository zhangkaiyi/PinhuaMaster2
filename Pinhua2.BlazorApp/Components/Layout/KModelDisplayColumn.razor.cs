using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using System.Linq.Expressions;

namespace Klazor
{
    public partial class KModelDisplayColumn : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public Expression<Func<MyMarkModel, bool>> Predicate { get; set; }
        //[CascadingParameter] public KModelDisplay Parent { get; set; }

        protected List<MyMarkModel> models;

        //[Inject] protected Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; }

        protected override void OnInitialized()
        {
            //models = MyMark.Parse(Parent.DataSource).Where(Predicate.Compile()).ToList();
        }

        protected override void OnParametersSet()
        {
        }
    }
}
