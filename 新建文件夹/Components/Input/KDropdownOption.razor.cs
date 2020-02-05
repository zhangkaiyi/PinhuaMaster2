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
using Microsoft.AspNetCore.Components.Rendering;

namespace Klazor
{
    public partial class KDropdownOption : ComponentBase
    {
        protected string Classname => new CssBuilder()
            .AddClass(Class)
            .Build();

        protected string inputValue
        {
            get
            {
                return Model.RawValueString;
            }
            set
            {
                Model.RawValueString = value;
            }
        }

        [Parameter] public MyMarkModel Model { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public string Text { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public string Class { get; set; }

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

        protected override void OnInitialized()
        {

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
