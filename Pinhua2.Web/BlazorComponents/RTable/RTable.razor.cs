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
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public partial class RTable<TRow> : ComponentBase, Blazui.Component.IContainerComponent
    {
        protected ElementReference headerElement;
        private bool requireRender { get; set; } = true;
        private bool visible = false;
        public List<RTableUserColumnConfig<TRow>> UserColumns { get; set; } = new List<RTableUserColumnConfig<TRow>>();

        public List<List<RTableColumnConfig>> AutoColumns { get; set; } = new List<List<RTableColumnConfig>>();

        public List<RTableCondition<TRow>> Conditions { get; set; } = new List<RTableCondition<TRow>>();

        public RTableReflectionData<TRow> ReflectionData { get; set; } = new RTableReflectionData<TRow>();

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
        /// 启用复选框列
        /// </summary>
        [Parameter]
        public bool CheckBoxHeader { get; set; }

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

        protected override void OnAfterRender(bool firstRender)
        {
            if (requireRender)
            {
                StateHasChanged();
                requireRender = false;
                return;
            }
            if (!visible)
            {
                visible = true;
                StateHasChanged();
            }
            RenderCompleted?.Invoke();
        }

        protected override void OnInitialized()
        {

        }

        protected override void OnParametersSet()
        {
            Console.WriteLine($"OnParametersSet, {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

            RTableConfigCreate();

            FillReflectionData();

            RefreshSelectAllStatus();
        }

        //protected void ApplyConditions(RTableColumnConfig cfg)
        //{
        //    foreach (var condition in Conditions)
        //    {
        //        cfg.Predicate = condition.Predicate;
        //        cfg.Eval = condition.Predicate.Compile();
        //        if (condition is RTableHiddenCondition<TRow> hiddenCondition)
        //        {
        //            cfg.IsHidden = hiddenCondition.IsHidden;
        //        }
        //        if (condition is RTableFormatCondition<TRow> formatCondition)
        //        {
        //            cfg.ColumnType = formatCondition.Type;
        //            cfg.ColumnFormat = formatCondition.Format;
        //        }
        //    }
        //}

        protected void FillReflectionData()
        {
            ReflectionData.Rows = new List<ReflectionRow>();

            foreach (var row in DataSource)
            {
                var rCells = from mm in MyMark.Parse(row)
                             select new ReflectionCell
                             {
                                 Model = mm
                             };
                var rRow = new ReflectionRow
                {
                    Cells = rCells.ToList()
                };
                ReflectionData.Rows.Add(rRow);
            }
        }

        protected void RTableConfigCreate()
        {
            AutoColumns = new List<List<RTableColumnConfig>>();
            foreach (var row in DataSource)
            {
                var rowModel = MyMark.Parse(row);
                var cfgs = rowModel.Select(cellModel => new RTableColumnConfig
                {
                    Model = cellModel,
                });
                foreach (var cfg in cfgs)
                {
                    //ApplyConditions(cfg);
                }
                AutoColumns.Add(cfgs.ToList());
            }
        }

        protected void RTableConfigInsert(TRow row)
        {
            var rowModel = MyMark.Parse(row);
            var cfgs = rowModel.Select(cellModel => new RTableColumnConfig
            {
                Model = cellModel,
            });
            foreach (var cfg in cfgs)
            {
                //ApplyConditions(cfg);
            }
            AutoColumns.Add(cfgs.ToList());
        }

        protected void RTableConfigRemove(int index)
        {
            AutoColumns.RemoveAt(index);
        }

        protected void Add(TRow row)
        {
            DataSource.Add(row);
            RTableConfigInsert(row);
        }

        protected void DoCondtions()
        {
            if (Conditions.Any())
            {
                foreach (var condition in Conditions)
                {
                    var eval = condition.Predicate.Compile();
                    foreach (var rowModel in AutoColumns)
                    {
                        var where = rowModel.Where(eval);
                        foreach (var cell in where)
                        {
                            cell.Predicate = condition.Predicate;
                            cell.Eval = eval;
                            if (condition is RTableHiddenCondition<TRow> hiddenCondition)
                            {
                                cell.IsHidden = hiddenCondition.IsHidden;
                            }
                            if (condition is RTableFormatCondition<TRow> formatCondition)
                            {
                                cell.ValueType = formatCondition.ValueType;
                                cell.ValueFormat = formatCondition.ValueFormat;
                            }
                        }
                    }
                }
            }
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
                SelectedRows = new HashSet<TRow>(DataSource);
            }
            else
            {
                SelectedRows = new HashSet<TRow>();
            }

            RefreshSelectAllStatus();
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
