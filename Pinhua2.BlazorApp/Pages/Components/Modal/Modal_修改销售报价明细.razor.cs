using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.DataAnnotations;
using System.Linq.Expressions;
using Pinhua2.ViewModels;
using Klazor;

namespace Piuhua2.Components.Modal
{
    public partial class Modal_修改销售报价明细 : ComponentBase
    {
        protected KModal modal;

        protected dto销售报价D currentDataSource
        {
            get
            {
                return DataSource;
            }
        }

        [Parameter] public dto销售报价D DataSource { get; set; }

        public void Show()
        {
            modal.Show();
        }

        public void Hide()
        {
            modal.Hide();
        }
    }
}
