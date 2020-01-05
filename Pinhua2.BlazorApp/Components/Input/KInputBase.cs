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
using System.Globalization;

namespace Klazor
{
    public abstract class KInputBase<TValue> : ComponentBase
    {
        protected string Classname => new CssBuilder("form-control")
            .AddClass(Class)
            .Build();

        [Inject] protected IJSRuntime jSRuntime { get; set; }

        [CascadingParameter] public KForm Form { get; set; }
        [CascadingParameter] public KFormGroupContainer KFormGroupContainer { get; set; }
        [CascadingParameter] public KFormGroup FormGroup { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public string Id { get; set; }
        [Parameter] public TValue Value { get; set; }
        [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool? Readonly { get; set; }
        [Parameter] public string Class { get; set; }
        [Parameter] public string Placeholder { get; set; }
        [Parameter] public virtual Func<TValue, string> Formatter { get; set; } = v => Convert.ToString(v);

        protected TValue currentValue
        {
            get => Value;
            set
            {
                Value = value;
                _ = ValueChanged.InvokeAsync(value);
            }
        }

        protected string currentValueAsString
        {
            get => FormatValueAsString(currentValue);
            set
            {
                if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.InvariantCulture, out var result))
                {
                    currentValue = result;
                }
            }
        }

        protected string currentId => string.IsNullOrEmpty(Id) ? FormGroup?.Label : Id;

        protected bool? currentReadonly => Readonly ?? FormGroup?.InputReadonly ?? KFormGroupContainer?.InputReadonly ?? Form?.InputReadonly;

        protected virtual string FormatValueAsString(TValue value) => value?.ToString();

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
            var propName = GetFieldName(propExpression);
            Set(propName, newValue);
        }

        private string GetFieldName(Expression<Func<KInput, object>> fieldGetter)
        {
            if (fieldGetter.Body is UnaryExpression unaryExpression)
            {
                return ((MemberExpression)unaryExpression.Operand).Member.Name;
            }
            return ((MemberExpression)fieldGetter.Body).Member.Name;
        }
    }
}
