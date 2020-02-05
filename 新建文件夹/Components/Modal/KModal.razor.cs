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
    public partial class KModal : ComponentBase
    {
        protected string Classname => new CssBuilder("modal")
            .AddClass("fade", IsFade)
            .AddClass(Class)
            .Build();
        protected string InnerClassname => new CssBuilder("modal-dialog")
            .AddClass($"modal-xs", Size == Size.ExtraSmall)
            .AddClass($"modal-sm", Size == Size.Small)
            .AddClass($"modal-md", Size == Size.Medium)
            .AddClass($"modal-lg", Size == Size.Large)
            .AddClass($"modal-xl", Size == Size.ExtraLarge)
            .AddClass("modal-dialog-centered", IsCentered)
            .Build();
        protected ElementReference Me { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public string Id { get; set; }
        [Parameter] public string ModalTitle { get; set; } = "Modal";
        [Parameter] public bool IsFade { get; set; } = false;
        [Parameter] public bool IsBackdrop { get; set; } = false;
        [Parameter] public bool IsCentered { get; set; } = false;
        [Parameter] public string Class { get; set; }
        [Parameter] public Size Size { get; set; } = Size.None;

        //[Inject] protected Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; }

        protected override void OnInitialized()
        {
            Id = $"g-{Guid.NewGuid().ToString("N")}";

            UnknownParameters = new Dictionary<string, object>();
            if (IsBackdrop)
            {
                UnknownParameters.TryAdd("data-backdrop", "static");
            }
            else
            {
                UnknownParameters.Remove("data-backdrop");
            }
        }

        public void Show()
        {
            JSRuntime.InvokeVoidAsync("klazor.showModal", $"#{Id}");
        }

        public void Hide()
        {
            JSRuntime.InvokeVoidAsync("klazor.hideModal", $"#{Id}");
        }

        public void Toggle()
        {
            JSRuntime.InvokeVoidAsync("klazor.toggleModal", $"#{Id}");
        }
    }
}
