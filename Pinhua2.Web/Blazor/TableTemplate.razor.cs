using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Blazor
{
    public partial class TableTemplate<TItem> : ComponentBase
    {
        [Parameter]
        public RenderFragment TableHeader { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter]
        public RenderFragment TableFooter { get; set; }

        [CascadingParameter(Name = "ProfileItems")]
        public IList<TItem> Items { get; set; }

        [CascadingParameter(Name = "EditModalId")]
        public string EditModalId { get; set; }

        [CascadingParameter(Name = "InsertModalId")]
        public string InsertModalId { get; set; }

        [Parameter]
        public Action<TItem, int> FromChild { get; set; }

        private void PassToParent(TItem item, int index)
        {
            FromChild(item, index);
        }
    }
}
