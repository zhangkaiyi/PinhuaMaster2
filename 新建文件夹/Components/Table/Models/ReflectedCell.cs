using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.DataAnnotations;

namespace Klazor
{
    public class ReflectedCell<TItem>
    {
        public MyAnnotationsModel Model { get; set; }
        public bool IsHidden { get; set; } = false;
        public KTableValueType ValueType { get; set; } = KTableValueType.Text;
        public string ValueFormat { get; set; } = string.Empty;

        public ReflectedCell<TItem> ApplyConditions(List<KTableCondition<TItem>> conditions)
        {
            foreach (var condition in conditions)
            {
                var eval = condition.Predicate.Compile();
                if (eval(this))
                {
                    if (condition is KTableHiddenCondition<TItem> hiddenCondition)
                    {
                        this.IsHidden = hiddenCondition.IsHidden;
                    }
                    else if (condition is KTableFormatCondition<TItem> formatCondition)
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
