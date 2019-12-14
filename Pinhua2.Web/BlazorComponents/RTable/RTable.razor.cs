using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Web.BlazorComponents.CheckBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public partial class RTable<TDataSource> : ComponentBase, Blazui.Component.IContainerComponent
    {
        [Inject] private IJSRuntime jsRunTime { get; set; }
        public ElementReference Container { get; set; }
        protected ElementReference headerElement;
        protected Status selectAllStatus;
        private bool isContainerHidden = true;
        private bool requireRender = true;
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
            new StyleBuilder("witdh", "100%")
            .AddStyle("height", Height + "px", Height > 0)
            .Build();

        public List<RTableUserColumnConfig<TDataSource>> UserColumns { get; set; } = new List<RTableUserColumnConfig<TDataSource>>();
        public ReflectionTable<TDataSource> ReflectionTable { get; set; } = new ReflectionTable<TDataSource>();

        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }

        [Parameter] public Action RenderCompleted { get; set; }

        [Parameter] public List<TDataSource> DataSource { get; set; } = new List<TDataSource>();

        [Parameter] public HashSet<TDataSource> SelectedRows { get; set; } = new HashSet<TDataSource>();

        [Parameter]
        public RenderFragment ChildContent { get; set; }

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

        protected override void OnInitialized()
        {

        }

        protected override void OnParametersSet()
        {
            FillReflectionTable();
            RefreshSelectAllStatus();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            ApplyConditions();
            if (requireRender)
            {
                if (isContainerHidden)
                {
                    isContainerHidden = false;
                    //StateHasChanged();
                }
                requireRender = false;
                StateHasChanged();
                return;
            }

            RenderCompleted?.Invoke();

        }

        protected void FillReflectionTable()
        {
            ReflectionTable = new ReflectionTable<TDataSource>();
            ReflectionTable.Rows = BuildReflectionRows();
            ReflectionTable.Cols = BuildReflectionCols();
            ReflectionTable.ColsNamed = BuildReflectionColsNamed();
        }

        protected void DoConditions()
        {
            foreach (var row in ReflectionTable.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    //cell.DoConditions(ReflectionTable.Conditions);
                }
            }
        }

        private List<ReflectionRow<TDataSource>> BuildReflectionRows()
        {
            var rRows = new List<ReflectionRow<TDataSource>>();
            foreach (var row in DataSource)
            {
                var rCells = from mm in MyMark.Parse(row)
                             select new ReflectionCell<TDataSource>
                             {
                                 Table = ReflectionTable,
                                 Model = mm,
                             };
                var rRow = new ReflectionRow<TDataSource>
                {
                    Cells = rCells.ToList()
                };
                rRows.Add(rRow);
            }
            return rRows;
        }

        private List<ReflectionCol<TDataSource>> BuildReflectionCols()
        {
            var rCols = new List<ReflectionCol<TDataSource>>();
            var rRow = MyMark.Parse(typeof(TDataSource));
            foreach (var cell in rRow)
            {
                rCols.Add(new ReflectionCol<TDataSource>());
            }
            foreach (var row in DataSource)
            {
                var rCells = (from mm in MyMark.Parse(row)
                              select new ReflectionCell<TDataSource>
                              {
                                  Model = mm
                              }).ToList();
                foreach (var rCell in rCells)
                {
                    rCols[rCells.IndexOf(rCell)].Cells.Add(rCell);
                }
            }
            return rCols;
        }

        private Dictionary<string, ReflectionCol<TDataSource>> BuildReflectionColsNamed()
        {
            var rCols = new Dictionary<string, ReflectionCol<TDataSource>>();
            var rRow = MyMark.Parse(typeof(TDataSource));
            foreach (var row in DataSource)
            {
                var rCells = (from mm in MyMark.Parse(row)
                              select new ReflectionCell<TDataSource>
                              {
                                  Model = mm
                              }).ToList();
                foreach (var rCell in rCells)
                {
                    rCols.TryAdd(rCell.Model.RawName, new ReflectionCol<TDataSource>());
                    rCols[rCell.Model.RawName].Cells.Add(rCell);
                }
            }
            return rCols;
        }

        protected void Add(TDataSource row)
        {
            var x = new Data.Models.view_AllOrdersPay
            {
                RecordId = 1987,
                业务类型 = "test",
                个数 = 1987,
                交期 = new DateTime(1987, 9, 22),
                仓 = "test",
                别名 = "test",
                日期 = new DateTime(1987, 9, 22)

            };
            DataSource.Add((TDataSource)(object)x);
            FillReflectionTable();
            StateHasChanged();
        }
        protected void RefreshSelectAllStatus()
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
            if (status == Status.Checked)
            {
                SelectedRows = new HashSet<TDataSource>(DataSource);
            }
            else
            {
                SelectedRows = new HashSet<TDataSource>();
            }

            RefreshSelectAllStatus();
        }

        protected void ChangeRowStatus(Status status, TDataSource row)
        {
            if (status == Status.Checked)
            {
                if (IsSingleSelect)
                {
                    SelectedRows = new HashSet<TDataSource>();
                }
                SelectedRows.Add(row);
            }
            else
            {
                SelectedRows.Remove(row);
            }
            RefreshSelectAllStatus();
        }

        protected void InverTDataSourceStatus(TDataSource row)
        {
            ChangeRowStatus(SelectedRows.Contains(row) ? Status.UnChecked : Status.Checked, row);
        }

        protected void RowClicked(TDataSource row)
        {
            if (IsClickToSelect)
            {
                InverTDataSourceStatus(row);
            }
        }

        public void ApplyConditions()
        {
            foreach (var row in ReflectionTable.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    foreach (var condition in ReflectionTable.Conditions)
                    {
                        var eval = condition.Predicate.Compile();
                        if (eval(cell))
                        {
                            if (condition is RTableHiddenCondition<TDataSource> hiddenCondition)
                            {
                                cell.IsHidden = hiddenCondition.IsHidden;
                            }
                            else if (condition is RTableFormatCondition<TDataSource> formatCondition)
                            {
                                cell.ValueType = formatCondition.ValueType;
                                cell.ValueFormat = formatCondition.ValueFormat;
                            }
                        }
                    }
                }
            }
        }
    }
}
