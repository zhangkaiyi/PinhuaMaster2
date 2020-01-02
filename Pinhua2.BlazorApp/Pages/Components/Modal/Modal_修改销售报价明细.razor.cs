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
        protected string[] dropdownItems => new[] { "片", "平方米", "延长米", "立方米", "套" };

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

        protected decimal? compute
        {
            get=> currentDataSource.个数 * currentDataSource.个数;
            set
            {
                currentDataSource.数量 = value;
            }
        }
    }
}
