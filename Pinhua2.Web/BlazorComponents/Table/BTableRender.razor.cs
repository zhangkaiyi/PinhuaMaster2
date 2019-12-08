using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.Table
{
    public partial class BTableRender<TRow> : ComponentBase
    {
        [Parameter]
        public BTable<TRow> Table { get; set; }

        public List<TableHeader<TRow>> Headers
        {
            get
            {
                return Table.Headers;
            }
        }
        public List<TRow> Rows
        {
            get
            {
                return Table.DataSource;
            }
        }
    }
}
