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
    public partial class KFormGroup<TValue> : ComponentBase
    {
        protected string labelClassname => new CssBuilder("col-form-label")
            .AddClass("text-right", LabelTextRight)
            .Build();

        protected string fieldName
        {
            get
            {
                return GetPropertyName(Field);
            }
        }

        protected string currentLabel
        {
            get
            {
                return string.IsNullOrEmpty(Label) ? fieldName : Label;
            }
        }

        protected string currentValue;

        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public TValue DataSource { get; set; }
        [Parameter] public Expression<Func<TValue, object>> Field { get; set; }
        [Parameter] public bool IsRequired { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public bool LabelTextRight { get; set; }

        private string GetPropertyName(Expression<Func<TValue, object>> propertyGetter)
        {
            if (propertyGetter.Body is UnaryExpression unaryExpression)
            {
                return ((MemberExpression)unaryExpression.Operand).Member.Name;
            }
            return ((MemberExpression)propertyGetter.Body).Member.Name;
        }
    }
}
