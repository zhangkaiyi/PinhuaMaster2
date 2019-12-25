using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.MyAnnotations;

namespace Klazor
{
    public partial class KDatePicker : ComponentBase
    {
        protected string Classname => new CssBuilder()
            .AddClass(Class)
            .Build();

        protected bool isFocus;
        protected bool isMouseOver;
        protected bool isVisible;
        protected string inputDate
        {
            get
            {
                if( DateTime.TryParse(Model?.Field?.Value?.ToString(), out var date))
                {
                    return date.ToString(string.IsNullOrEmpty(Format) ? "" : Format);
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                Model.Field.Value = value;
            }
        }

        [Parameter] public MyAnnotationsModel Model { get; set; }
        [Parameter] public string Format { get; set; }
        //[Parameter] public string Id { get; set; } = string.Empty;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public string Class { get; set; }
        [Parameter] public string Placeholder { get; set; }

        //[Inject] protected Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; }

        protected override void OnInitialized()
        {

        }
    }
}
