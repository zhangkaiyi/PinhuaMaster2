using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public abstract class KTableHiddenConditionBase<TItem> : KTableConditionBase<TItem>
    {
        public bool IsHidden { get; set; } = true;

    }
}
