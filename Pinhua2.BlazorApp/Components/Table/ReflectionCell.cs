using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Klazor
{
    public class ReflectionCell<TItem>
    {
        public MyMarkModel Model { get; set; }
        public bool IsHidden { get; set; } = false;
        public RTableValueType ValueType { get; set; } = RTableValueType.Text;
        public string ValueFormat { get; set; } = string.Empty;

        public ReflectionCell<TItem> ApplyConditions(List<KTableConditionBase<TItem>> conditions)
        {
            foreach (var condition in conditions)
            {
                var eval = condition.Predicate.Compile();
                if (eval(this))
                {
                    if (condition is KTableHiddenConditionBase<TItem> hiddenCondition)
                    {
                        this.IsHidden = hiddenCondition.IsHidden;
                    }
                    else if (condition is KTableFormatConditionBase<TItem> formatCondition)
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
