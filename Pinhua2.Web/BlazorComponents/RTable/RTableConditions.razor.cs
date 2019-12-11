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
    public partial class RTableConditions<TRow> : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        public RTable<TRow> Table { get; set; }

        public void AddCondition(RTableCondition<TRow> condition)
        {
            if (!Table.ConditionModels.Any())
            {
                foreach (var row in Table.DataSource)
                {
                    var rowModel = MyMark.Parse(row);
                    var cfg = rowModel.Select(cellModel => new RTableColumnConfig
                    {
                        Model = cellModel,
                    });
                    Table.ConditionModels.Add(cfg.ToList());
                }
            }
            if (Table.ConditionModels.Any())
            {
                foreach (var rowModel in Table.ConditionModels)
                {
                    var where = rowModel.Where(condition.Predicate.Compile());
                    foreach (var cell in where)
                    {
                        cell.Predicate = condition.Predicate;
                        cell.Eval = condition.Predicate.Compile();
                        if (condition is RTableHiddenCondition<TRow> hiddenCondition)
                        {
                            cell.IsHidden = hiddenCondition.IsHidden;
                        }
                        if (condition is RTableFormatCondition<TRow> formatCondition)
                        {
                            cell.ColumnType = formatCondition.Type;
                            cell.ColumnFormat = formatCondition.Format;
                        }
                    }
                }
            }
        }
    }
}
