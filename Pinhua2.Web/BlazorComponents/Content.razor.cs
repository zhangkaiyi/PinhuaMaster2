using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents
{
    public partial class Content<TItem> : ComponentBase
    {
        private const string editModalId = "editModal";
        private const string insertModalId = "insertModal";

        private TItem editingItem { get; set; }

        private int editingIndex { get; set; }

        [Parameter]
        public IList<TItem> Items { get; set; }

        protected override void OnInitialized()
        {
            editingItem = (TItem)Activator.CreateInstance(typeof(TItem));
        }

        private void ReceivedItemFromTable(TItem item, int index)
        {
            editingItem = item;
            editingIndex = index;
            StateHasChanged();
        }

        private void ReceivedItemFromDialog(TItem item, int index)
        {
            Items[editingIndex] = item;
            StateHasChanged();
        }
    }
}
