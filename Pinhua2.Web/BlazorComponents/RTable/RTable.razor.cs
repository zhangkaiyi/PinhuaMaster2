using Blazui.Component.Dom;
using Blazui.Component.EventArgs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Web.BlazorComponents.CheckBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public partial class RTable<TRow> : ComponentBase, Blazui.Component.IContainerComponent
    {
        protected ElementReference headerElement;
        private bool requireRender = true;
        public List<RTableHeader<TRow>> Headers { get; set; } = new List<RTableHeader<TRow>>();

        public List<List<MyMarkModel>> MarkModels = new List<List<MyMarkModel>>();

        public List<List<RTableColumnConfig>> ConditionModels = new List<List<RTableColumnConfig>>();

        [Parameter]
        public Action RenderCompleted { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        [Parameter]
        public int Total { get; set; } = 100;

        /// <summary>
        /// 每页条数
        /// </summary>
        [Parameter]
        public int PageSize { get; set; } = 50;
        /// <summary>
        /// 当前页码，从1开始
        /// </summary>
        [Parameter]
        public int CurrentPage { get; set; } = 1;
        [Parameter]
        public List<TRow> DataSource { get; set; } = new List<TRow>();

        [Parameter]
        public HashSet<TRow> SelectedRows { get; set; } = new HashSet<TRow>();

        protected Status selectAllStatus;

        [Inject]
        private IJSRuntime jsRunTime { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public int Height { get; set; }

        /// <summary>
        /// 启用斑马纹
        /// </summary>
        [Parameter]
        public bool IsStripe { get; set; }

        /// <summary>
        /// 启用边框
        /// </summary>
        [Parameter]
        public bool IsBordered { get; set; }

        /// <summary>
        /// 启用文本不换行
        /// </summary>
        [Parameter]
        public bool IsTextNoWrap { get; set; }

        /// <summary>
        /// 启用悬停加亮
        /// </summary>
        [Parameter]
        public bool IsHover { get; set; }

        /// <summary>
        /// 启用响应式
        /// </summary>
        [Parameter]
        public bool IsResponsive { get; set; }

        /// <summary>
        /// 启用单击选中
        /// </summary>
        [Parameter]
        public bool IsClickToSelect { get; set; }

        /// <summary>
        /// 启用单选
        /// </summary>
        [Parameter]
        public bool IsSingleSelect { get; set; }

        public ElementReference Container { get; set; }

        public ElementReference abc { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (requireRender)
            {
                StateHasChanged();
                requireRender = false;
                return;
            }
            RenderCompleted?.Invoke();
        }

        protected override void OnInitialized()
        {

        }

        protected override void OnParametersSet()
        {
            RefreshSelectAllStatus();
        }

        void RefreshSelectAllStatus()
        {
            if (DataSource.Count == 0 || SelectedRows.Count == 0)
            {
                selectAllStatus = Status.UnChecked;
            }
            else if (DataSource.Count > SelectedRows.Count)
            {
                selectAllStatus = Status.Indeterminate;
            }
            else
            {
                selectAllStatus = Status.Checked;
            }
        }

        protected void ChangeAllStatus(Status status)
        {
            if (!IsSingleSelect)
            {
                if (status == Status.Checked)
                {
                    SelectedRows = new HashSet<TRow>(DataSource);
                }
                else
                {
                    SelectedRows = new HashSet<TRow>();
                }

                RefreshSelectAllStatus();
            }
        }

        protected void ChangeRowStatus(Status status, TRow row)
        {
            if (status == Status.Checked)
            {
                if (IsSingleSelect)
                {
                    SelectedRows = new HashSet<TRow>();
                }
                SelectedRows.Add(row);
            }
            else
            {
                SelectedRows.Remove(row);
            }
            RefreshSelectAllStatus();
        }

        protected void InvertRowStatus(TRow row)
        {
            ChangeRowStatus(SelectedRows.Contains(row) ? Status.UnChecked : Status.Checked, row);
        }

        protected void RowClicked(TRow row)
        {
            if (IsClickToSelect)
            {
                InvertRowStatus(row);
            }
        }
    }
}
