using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Klazor
{
    public abstract class RTableUserColumnsBase<TRow> : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        public KTableBase<TRow> Table { get; set; }

        public void AddColumn(RTableUserColumnBase<TRow> column)
        {
            var columnConfig = new RTableUserColumnConfig<TRow>
            {
                Column = column,
                Property = column.Property == null ? string.Empty : GetPropertyName(column.Property),
                Eval = column.Property == null ? null : column.Property.Compile(),
                Text = column.Text,
                Width = column.Width,
                IsCheckBox = column.IsCheckBox,
                Template = column.ChildContent
            };

            var exsisted = Table.UserColumns.Any(c => c.Column == columnConfig.Column);
            if (!exsisted)
                Table.UserColumns.Add(columnConfig);
        }

        private string GetPropertyName(Expression<Func<TRow, object>> propertyGetter)
        {
            if (propertyGetter.Body is UnaryExpression unaryExpression)
            {
                return ((MemberExpression)unaryExpression.Operand).Member.Name;
            }
            return ((MemberExpression)propertyGetter.Body).Member.Name;
        }
    }
}
