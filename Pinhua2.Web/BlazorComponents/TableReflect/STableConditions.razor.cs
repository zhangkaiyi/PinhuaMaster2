using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.TableReflect
{
    public partial class STableConditions<TRow> : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        public STable<TRow> Table { get; set; }

        public void AddCondition(STableCondition<TRow> condition)
        {
            //var columnConfig = new TableHeader<TRow>
            //{
            //    Property = column.Property == null ? string.Empty : GetPropertyName(column.Property),
            //    Eval = column.Property == null ? null : column.Property.Compile(),
            //    Text = column.Text,
            //    Width = column.Width,
            //    IsCheckBox = column.IsCheckBox,
            //    Template = column.ChildContent
            //};
            //Table.Headers.Add(columnConfig);
            if (!Table.ConditionModels.Any())
            {
                foreach (var models in Table.MarkModels)
                {
                    var r = models.Select(m => new MyMarkModelWithOperation
                    {
                        Model = m,
                        Hidden = false,
                    });
                    Table.ConditionModels.Add(r.ToList());
                }
            }
            if(Table.ConditionModels.Any())
            {
                foreach (var models in Table.ConditionModels)
                {
                    var eval = condition.Predicate.Compile();
                    var shouyingxiang = models.Where(eval).ToList();
                    foreach (var item in models)
                    {
                        if (shouyingxiang.Contains(item))
                        {
                            //Console.WriteLine(condition.Predicate);
                            item.Model.BlazorValue = "change";
                            //item.Hidden = condition.IsHidden;
                        }
                    }
                }
            }
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
