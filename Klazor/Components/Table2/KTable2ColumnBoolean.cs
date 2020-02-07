using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public class KTable2ColumnBoolean : KTable2Column
    {
        internal override bool IsBoolean { get; set; } = true;
    }
}
