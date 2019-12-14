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
        [Parameter] public RenderFragment ChildContent { get; set; }
        [CascadingParameter] public RTable<TRow> Table { get; set; }

        public void AddCondition(RTableCondition<TRow> condition)
        {
            if (!Table.ReflectionTable.Conditions.Contains(condition))
            {
                Table.ReflectionTable.Conditions.Add(condition);
            }
        }

        public void ApplyCondition(RTableCondition<TRow> condition)
        {
            if (Table.ReflectionTable.Rows.Any())
            {
                foreach (var rRow in Table.ReflectionTable.Rows)
                {
                    foreach (var cell in rRow.Cells.Where(condition.Predicate.Compile()))
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
