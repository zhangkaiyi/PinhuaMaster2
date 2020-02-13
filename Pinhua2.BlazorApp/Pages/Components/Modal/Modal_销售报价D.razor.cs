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
using AutoMapper;
using Pinhua2.Data;

namespace Piuhua2.Components.Modal
{
    public partial class Modal_销售报价D : ComponentBase
    {
        protected KModal modal;
        protected KTable2 table;

        protected List<combo销售报价> DataSource;
        protected List<dto销售报价D> currentDataSource
        {
            get
            {
                if (FilterExpression != null)
                {
                    return Mapper.Map<IEnumerable<dto销售报价D>>(DataSource.Where(FilterExpression.Compile()).Select(d => d.Detail)).ToList();
                }
                else
                {
                    return Mapper.Map<IEnumerable<dto销售报价D>>(DataSource.Select(d=>d.Detail)).ToList();
                }
            }
        }
        [Inject] IMapper Mapper { get; set; }
        [Inject] Pinhua2Context PinhuaContext { get; set; }

        [Parameter] public bool IsSingleSelect { get; set; } = false;
        [Parameter] public EventCallback<Modal_销售报价D> OnOK { get; set; }
        [Parameter] public EventCallback<Modal_销售报价D> OnCancel { get; set; }
        [Parameter] public Expression<Func<combo销售报价, bool>> FilterExpression { get; set; }

        protected override void OnInitialized()
        {
            DataSource = PinhuaContext.GetViews().销售.销售报价combo();
        }

        public void Show()
        {
            table.ChangeAllStatus(CheckBoxStatus.UnChecked);
            modal.Show();
        }

        public HashSet<object> SelectedProducts
        {
            get { return table.SelectedRows; }
        }
    }
}
