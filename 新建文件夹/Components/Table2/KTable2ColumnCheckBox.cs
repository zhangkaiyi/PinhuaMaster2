using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public class KTable2ColumnCheckBox : KTable2Column
    {
        internal override bool IsCheckBox { get; set; } = true;
    }
}
