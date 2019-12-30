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

namespace Klazor
{
    public partial class KInputText : ComponentBase
    {
        protected string Classname => new CssBuilder("form-control")
            .AddClass(Class)
            .Build();

        protected string modelValue
        {
            get
            {
                return Model.Field.ValueString;
            }
            set
            {
                Model.Field.ValueString = value;
            }
        }

        [Inject] protected IJSRuntime jSRuntime { get; set; }


        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public MyAnnotationsModel Model { get; set; }
        [Parameter] public string Id { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool? Readonly { get; set; }
        [Parameter] public string Class { get; set; }
        [Parameter] public string Placeholder { get; set; }

        protected string CurrentValue
        {
            get => Value;
            set
            {
                Value = value;
                _ = ValueChanged.InvokeAsync(value);
            }
        }

        public void Set(string propName, object newValue)
        {
            var prop = this.GetType().GetProperty(propName);
            var oldValue = prop.GetValue(this);
            if (!oldValue.Equals(newValue))
            {
                prop.SetValue(this, newValue);
                StateHasChanged();
            }
        }

        public void Set(Expression<Func<KInput, object>> propExpression, object newValue)
        {
            var propName = GetPropertyName(propExpression);
            Set(propName, newValue);
        }

        private string GetPropertyName(Expression<Func<KInput, object>> propertyGetter)
        {
            if (propertyGetter.Body is UnaryExpression unaryExpression)
            {
                return ((MemberExpression)unaryExpression.Operand).Member.Name;
            }
            return ((MemberExpression)propertyGetter.Body).Member.Name;
        }
    }
}
