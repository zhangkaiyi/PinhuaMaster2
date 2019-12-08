using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.Table
{
    public partial class BTableCheckBoxColumn<TRow> : BTableColumn<TRow>
    {
        internal override bool IsCheckBox { get; set; } = true;
    }
}
