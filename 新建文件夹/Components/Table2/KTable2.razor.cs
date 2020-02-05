using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public partial class KTable2 : ComponentBase
    {
        protected bool firstRun = true;
        protected bool secondRun = true;
        protected bool hideContainer = true;
        public ElementReference Container { get; set; }
        protected CheckBoxStatus selectAllStatus;
        protected string Classname =>
            new CssBuilder("table")
            .AddClass("table-dark", IsDark)
            .AddClass("table-striped", IsStriped)
            .AddClass("table-bordered", IsBordered)
            .AddClass("table-borderless", IsBorderless)
            .AddClass("table-hover", IsHovarable)
            .AddClass("table-sm", IsSmall)
            .AddClass("text-nowrap", IsTextNoWrap)
            .AddClass(Class)
            .Build();

        protected string Stylename =>
            new StyleBuilder("width", "100%")
            .AddStyle("height", Height + "px", Height > 0)
            .Build();

        protected int? currentActiveRow { get; set; }

        internal List<object> Rows = new List<object>();
        internal Type RowType;

        public List<KTable2ColumnSetting> UserColumns { get; set; } = new List<KTable2ColumnSetting>();

        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }

        [Parameter] public bool AutoGenerateColumns { get; set; } = true;

        [Parameter] public bool EnableTableActive { get; set; } = true;

        [Parameter] public Action RenderCompleted { get; set; }

        [Parameter] public object DataSource { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        [Parameter] public int PageSize { get; set; } = 20;
        /// <summary>
        /// 当前页数
        /// </summary>
        [Parameter] public int CurrentPage { get; set; } = 1;
        /// <summary>
        /// 当只有一页时，不显示分页
        /// </summary>
        [Parameter] public bool NoPaginationOnSinglePage { get; set; } = true;

        [Parameter] public HashSet<object> SelectedRows { get; set; } = new HashSet<object>();

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public int Height { get; set; }

        /// <summary>
        /// 启用黑暗模式
        /// </summary>
        [Parameter] public bool IsDark { get; set; }

        /// <summary>
        /// 启用斑马纹
        /// </summary>
        [Parameter] public bool IsStriped { get; set; }

        /// <summary>
        /// 启用边框
        /// </summary>
        [Parameter] public bool IsBordered { get; set; }

        /// <summary>
        /// 启用无外框
        /// </summary>
        [Parameter] public bool IsBorderless { get; set; }

        /// <summary>
        /// 启用文本不换行
        /// </summary>
        [Parameter] public bool IsTextNoWrap { get; set; }

        /// <summary>
        /// 启用悬停加亮
        /// </summary>
        [Parameter] public bool IsHovarable { get; set; }

        /// <summary>
        /// 启用小号列表
        /// </summary>
        [Parameter] public bool IsSmall { get; set; }

        /// <summary>
        /// 启用响应式
        /// </summary>
        [Parameter] public bool IsResponsive { get; set; }

        /// <summary>
        /// 启用复选框列
        /// </summary>
        [Parameter] public bool CheckBoxHeader { get; set; }

        /// <summary>
        /// 启用自定义类
        /// </summary>
        [Parameter] public string Class { get; set; }

        /// <summary>
        /// 启用单击选中
        /// </summary>
        [Parameter] public bool IsClickToSelect { get; set; }

        /// <summary>
        /// 启用单选
        /// </summary>
        [Parameter] public bool IsSingleSelect { get; set; }

        [Parameter] public EventCallback<KTable2Event> OnRowClicking { get; set; }
        [Parameter] public EventCallback<KTable2Event> OnRowClicked { get; set; }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
            if(parameters.GetValueOrDefault<object>(nameof(DataSource)) != null)
            {
                Rows = (DataSource as IEnumerable).Cast<object>().ToList();
                RowType = DataSource.GetType().GetGenericArguments()[0];
            }
            RefreshSelectAllStatus();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRun)
            {
                // 第一次执行，执行if语句true的部分
                firstRun = false;
                hideContainer = false;
                StateHasChanged();
                return;
            }
            
            RenderCompleted?.Invoke();

        }

        protected void RefreshSelectAllStatus()
        {
            if (Rows.Count == 0 || SelectedRows.Count == 0)
            {
                selectAllStatus = CheckBoxStatus.UnChecked;
            }
            else if (Rows.Count > SelectedRows.Count)
            {
                selectAllStatus = CheckBoxStatus.Indeterminate;
            }
            else
            {
                selectAllStatus = CheckBoxStatus.Checked;
            }
            StateHasChanged();
        }

        public void ChangeAllStatus(CheckBoxStatus status)
        {
            if (status == CheckBoxStatus.Checked)
            {
                SelectedRows = new HashSet<object>(Rows);
            }
            else
            {
                SelectedRows = new HashSet<object>();
            }

            RefreshSelectAllStatus();
        }

        public void ChangeRowStatus(CheckBoxStatus status, object row)
        {
            if (status == CheckBoxStatus.Checked)
            {
                if (IsSingleSelect)
                {
                    SelectedRows = new HashSet<object>();
                }
                SelectedRows.Add(row);
            }
            else
            {
                SelectedRows.Remove(row);
            }
            RefreshSelectAllStatus();
        }

        protected void InverTItemStatus(object row)
        {
            ChangeRowStatus(SelectedRows.Contains(row) ? CheckBoxStatus.UnChecked : CheckBoxStatus.Checked, row);
        }

        protected void RowClicked(object row)
        {
            currentActiveRow = Rows.IndexOf(row);

            var KTable2Event = new KTable2Event
            {
                Target = this,
                Row = row
            };

            OnRowClicking.InvokeAsync(KTable2Event);

            if (IsClickToSelect)
            {
                InverTItemStatus(row);
            }

            OnRowClicked.InvokeAsync(KTable2Event);
        }

        public void SetDataSource(object dataSource)
        {
            DataSource = dataSource;
        }
    }
}
