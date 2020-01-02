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
using System.Globalization;

namespace Klazor
{
    public partial class KFormGroup2<TModel, TValue> : ComponentBase
    {
        protected string labelClassname => new CssBuilder("col-form-label")
            .AddClass("text-left", (Form?.LabelAlign) == LabelAlign.Left)
            .AddClass("text-center", (Form?.LabelAlign) == LabelAlign.Center)
            .AddClass("text-right", (Form?.LabelAlign) == LabelAlign.Right)
            .Build();

        protected string fieldName
        {
            get
            {
                return GetFieldName(Field);
            }
        }

        protected string currentLabel
        {
            get
            {
                return string.IsNullOrEmpty(Label) ? fieldName : Label;
            }
        }

        protected string currentValue
        {
            get
            {
                return typeof(TModel).GetProperty(fieldName)?.GetValue(Model)?.ToString();
            }
            set
            {
                if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.InvariantCulture, out var result))
                {
                    typeof(TModel).GetProperty(fieldName)?.SetValue(Model, result);
                }
                else
                {
                    typeof(TModel).GetProperty(fieldName)?.SetValue(Model, default);
                }
            }
        }

        protected bool? currentReadonly
        {
            get
            {
                return InputReadonly ?? Form?.InputReadonly;
            }
        }

        [CascadingParameter] public KForm Form { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        [Parameter] public TModel Model { get; set; }
        [Parameter] public Expression<Func<TModel, TValue>> Field { get; set; }
        [Parameter] public bool IsRequired { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public bool? InputReadonly { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        private string GetFieldName(Expression<Func<TModel, TValue>> fieldGetter)
        {
            if (fieldGetter.Body is UnaryExpression unaryExpression)
            {
                return ((MemberExpression)unaryExpression.Operand).Member.Name;
            }
            return ((MemberExpression)fieldGetter.Body).Member.Name;
        }
    }
}
