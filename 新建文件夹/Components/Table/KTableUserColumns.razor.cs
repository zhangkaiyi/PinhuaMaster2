using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Klazor
{
    public partial class KTableUserColumns<TItem> : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        public KTable<TItem> Table { get; set; }

        public void AddColumn(KTableUserColumn<TItem> column)
        {
            var columnConfig = new RTableUserColumnConfig<TItem>
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

        private string GetPropertyName(Expression<Func<TItem, object>> propertyGetter)
        {
            if (propertyGetter.Body is UnaryExpression unaryExpression)
            {
                return ((MemberExpression)unaryExpression.Operand).Member.Name;
            }
            return ((MemberExpression)propertyGetter.Body).Member.Name;
        }
    }
}
