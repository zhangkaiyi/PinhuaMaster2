using Microsoft.AspNetCore.Components;
using System;
using System.Globalization;
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
                    if (value == null)
                    {
                        return null;
                    }

                    if (string.IsNullOrWhiteSpace(column.Format))
                    {
                        switch (value)
                        {
                            case null:
                                return null;

                            case int @int:
                                return BindConverter.FormatValue(@int, CultureInfo.InvariantCulture);

                            case long @long:
                                return BindConverter.FormatValue(@long, CultureInfo.InvariantCulture);

                            case float @float:
                                return BindConverter.FormatValue(@float, CultureInfo.InvariantCulture);

                            case double @double:
                                return BindConverter.FormatValue(@double, CultureInfo.InvariantCulture);

                            case decimal @decimal:
                                var result = BindConverter.FormatValue(@decimal, CultureInfo.InvariantCulture).Split('.');
                                if (string.IsNullOrEmpty(result.ElementAtOrDefault(1)?.TrimEnd('0')))
                                    return result[0];
                                else
                                    return string.Join('.', result[0], result[1]?.TrimEnd('0'));

                            case bool @bool:
                                if (column.IsBoolean)
                                {
                                    return @bool ? "是" : "否";
                                }
                                else
                                {
                                    return @bool;
                                }

                            default:
                                return value;
                        }
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
                Text = string.IsNullOrWhiteSpace(column.Text) ? column.Field : column.Text,
                Width = column.Width,
                IsCheckBox = column.IsCheckBox,
                Template = column.ChildContent,
                Format = column.Format
            };

            var exsisted = false;
            if (string.IsNullOrEmpty(columnConfig.Field))
            {
                exsisted = Table.UserColumns.Any(c => c.Template == columnConfig.Template);
            }
            else
            {
                exsisted = Table.UserColumns.Any(c => c.Field == columnConfig.Field);
            }
            if (!exsisted)
                Table.UserColumns.Add(columnConfig);
        }
    }
}
