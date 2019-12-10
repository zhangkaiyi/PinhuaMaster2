using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Blazor.Modal
{
    public partial class EditModal<TItem> : ComponentBase
    {
        [CascadingParameter(Name = "EditModalId")]
        public string EditModalId { get; set; }

        [CascadingParameter(Name = "InsertModalId")]
        public string InsertModalId { get; set; }

        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public TItem Item { get; set; }

        [Parameter]
        public Action<TItem, int> FromChild { get; set; }

        protected override void OnInitialized()
        {

        }

        private void PassToParent()
        {
            FromChild(Item, Index);
        }
    }
}
