using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public partial class RTableUserColumnCheckBox<TRow> : RTableUserColumn<TRow>
    {
        internal override bool IsCheckBox { get; set; } = true;
    }
}
