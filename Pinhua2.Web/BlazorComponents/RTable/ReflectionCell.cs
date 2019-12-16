using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public class ReflectionCell<TDataSource>
    {
        public ReflectionTable<TDataSource> Table { get; set; }
        public MyMarkModel Model { get; set; }
        public bool IsHidden { get; set; } = false;
        public RTableValueType ValueType { get; set; } = RTableValueType.Text;
        public string ValueFormat { get; set; } = string.Empty;

        public ReflectionCell<TDataSource> ApplyConditions(List<RTableCondition<TDataSource>> conditions)
        {
            foreach (var condition in conditions)
            {
                var eval = condition.Predicate.Compile();
                if (eval(this))
                {
                    if (condition is RTableHiddenCondition<TDataSource> hiddenCondition)
                    {
                        this.IsHidden = hiddenCondition.IsHidden;
                    }
                    else if (condition is RTableFormatCondition<TDataSource> formatCondition)
                    {
                        this.ValueType = formatCondition.ValueType;
                        this.ValueFormat = formatCondition.ValueFormat;
                    }
                }
            }
            return this;
        }
        public ReflectionCell<TDataSource> Do()
        {
            foreach (var condition in Table.Conditions)
            {
                var eval = condition.Predicate.Compile();
                if (eval(this))
                {
                    if (condition is RTableHiddenCondition<TDataSource> hiddenCondition)
                    {
                        this.IsHidden = hiddenCondition.IsHidden;
                    }
                    else if (condition is RTableFormatCondition<TDataSource> formatCondition)
                    {
                        this.ValueType = formatCondition.ValueType;
                        this.ValueFormat = formatCondition.ValueFormat;
                    }
                }
            }
            return this;
        }
    }
}
