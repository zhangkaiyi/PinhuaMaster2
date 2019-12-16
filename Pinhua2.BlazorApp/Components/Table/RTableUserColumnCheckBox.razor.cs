using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public partial class RTableUserColumnCheckBox<TRow> : RTableUserColumnBase<TRow>
    {
        internal override bool IsCheckBox { get; set; } = true;
    }
}
