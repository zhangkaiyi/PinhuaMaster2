using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Klazor
{
    public partial class KTable2Columns : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        public KTable2 Table { get; set; }

        public void AddColumn(KTable2Column column)
        {
            var columnConfig = new KTable2ColumnSetting
            {
                Column = column,
                Field = column.Field?? string.Empty,
                Text = column.Text,
                Width = column.Width,
                IsCheckBox = column.IsCheckBox,
                Template = column.ChildContent
            };

            var exsisted = Table.UserColumns.Any(c => c.Column == columnConfig.Column);
            if (!exsisted)
                Table.UserColumns.Add(columnConfig);
        }

        private string GetPropertyName(Expression<Func<object, object>> propertyGetter)
        {
            if (propertyGetter.Body is UnaryExpression unaryExpression)
            {
                return ((MemberExpression)unaryExpression.Operand).Member.Name;
            }
            return ((MemberExpression)propertyGetter.Body).Member.Name;
        }
    }
}
