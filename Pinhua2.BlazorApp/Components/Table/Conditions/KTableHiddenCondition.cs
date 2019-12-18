using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public partial class KTableHiddenCondition<TItem> : KTableCondition<TItem>
    {
        public bool IsHidden { get; set; } = true;

    }
}
