using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public partial class RTableConditionContainer<TRow> : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        public RTable<TRow> Table { get; set; }

        public void AddCondition(RTableCondition<TRow> condition)
        {
            // way1
            if (!Table.Conditions.Contains(condition))
            {
                Table.Conditions.Add(condition);
            }
            // way2
            if (!Table.ReflectionData.Conditions.Contains(condition))
            {
                Table.Conditions.Add(condition);
            }

            // way1
            if (Table.AutoColumns.Any())
            {
                var eval = condition.Predicate.Compile();
                foreach (var rowModel in Table.AutoColumns)
                {
                    var where = rowModel.Where(eval);
                    foreach (var cell in where)
                    {
                        cell.Predicate = condition.Predicate;
                        cell.Eval = eval;
                        if (condition is RTableHiddenCondition<TRow> hiddenCondition)
                        {
                            cell.IsHidden = hiddenCondition.IsHidden;
                        }
                        if (condition is RTableFormatCondition<TRow> formatCondition)
                        {
                            cell.ValueType = formatCondition.ValueType;
                            cell.ValueFormat = formatCondition.ValueFormat;
                        }
                    }
                }
            }
            // way2
            if (Table.ReflectionData.Rows.Any())
            {
                foreach (var rRow in Table.ReflectionData.Rows)
                {
                    foreach(var cell in rRow.Cells.Where(condition.Predicate2.Compile()))
                    {
                        if (condition is RTableHiddenCondition<TRow> hiddenCondition)
                        {
                            cell.IsHidden = hiddenCondition.IsHidden;
                        }
                        else if (condition is RTableFormatCondition<TRow> formatCondition)
                        {
                            cell.ValueType = formatCondition.ValueType;
                            cell.ValueFormat = formatCondition.ValueFormat;
                        }
                    }
                }
            }
        }
    }
}
