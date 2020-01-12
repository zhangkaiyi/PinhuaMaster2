using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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
            if (Table.RowType == null)
            {
                throw new InvalidOperationException($"表格 {Table.GetType().Name} 没有设置 DataType 属性");
            }
            if (column.Field == null && !(column is KTable2Column))
            {
                throw new InvalidOperationException($"列 {column.Text} 没有设置 {nameof(KTable2Column.Field)} 属性");
            }

            PropertyInfo property = null;
            if (!string.IsNullOrWhiteSpace(column.Field))
            {
                property = Table.RowType.GetProperty(column.Field);
                if (property == null)
                {
                    throw new InvalidOperationException($"属性 {column.Field} 在 {Table.RowType.Name} 中不存在");
                }
            }
            var columnConfig = new KTable2ColumnSetting
            {
                Field = column.Field,
                Property = property,
                Eval = column.Field == null ? null : (Func<object, object>)(row =>
                {
                    var value = property.GetValue(row);
                    if (string.IsNullOrWhiteSpace(column.Format))
                    {
                        return value;
                    }
                    if (value == null)
                    {
                        return null;
                    }

                    try
                    {
                        return Convert.ToDateTime(value).ToString(column.Format);
                    }
                    catch (InvalidCastException)
                    {
                        throw new InvalidOperationException("仅日期列支持 Format 参数");
                    }
                }),
                Text = column.Text,
                Width = column.Width,
                IsCheckBox = column.IsCheckBox,
                Template = column.ChildContent,
                Format = column.Format
            };

            var exsisted = Table.UserColumns.Any(c => c.Field == columnConfig.Field);
            if (!exsisted)
                Table.UserColumns.Add(columnConfig);
        }
    }
}
