using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public class KTableUserColumnCheckBox<TRow> : KTableUserColumn<TRow>
    {
        internal override bool IsCheckBox { get; set; } = true;
    }
}
