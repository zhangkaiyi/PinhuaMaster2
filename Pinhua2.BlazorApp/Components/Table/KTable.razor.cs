using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Klazor
{
    public partial class KTable<TItem> : ComponentBase
    {
        protected bool firstRun = true;
        protected bool refreshRDataSource = false;
        public ElementReference Container { get; set; }
        protected Status selectAllStatus;
        protected bool hideContainer = true;
        protected bool requireRender = true;
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

        public List<RTableUserColumnConfig<TItem>> UserColumns { get; set; } = new List<RTableUserColumnConfig<TItem>>();

        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }

        [Parameter] public Action RenderCompleted { get; set; }

        [Parameter] public List<TItem> DataSource { get; set; } = new List<TItem>();

        public List<RDataSource<TItem>> RDataSource = new List<RDataSource<TItem>>();
        public List<KTableConditionBase<TItem>> RConditions = new List<KTableConditionBase<TItem>>();

        [Parameter] public HashSet<TItem> SelectedRows { get; set; } = new HashSet<TItem>();

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment ConditionContainer { get; set; }

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
            //FillReflectionTable(ReflectionTable);
        }

        protected override void OnParametersSet()
        {
            //makeRDataSource = true;
            MakeAllRDataSource();
            RefreshSelectAllStatus();
        }

        protected void MakeAllRDataSource()
        {
            RDataSource = new List<RDataSource<TItem>>();
            foreach (var row in DataSource)
            {
                var rRow = new RDataSource<TItem>();
                rRow.Data = row;
                rRow.RData = MyMark.Parse(row).Select(m =>
                new ReflectionCell<TItem>
                {
                    Model = m
                }.ApplyConditions(RConditions)).ToList();

                RDataSource.Add(rRow);
            }
        }

        protected void MakeOneRDataSource(TItem row)
        {
            var rRow = new RDataSource<TItem>();
            rRow.Data = row;
            rRow.RData = (from m in MyMark.Parse(row)
                          select new ReflectionCell<TItem>
                          {
                              Model = m
                          }.ApplyConditions(RConditions))
                          .ToList();

            RDataSource.Add(rRow);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRun)
            {
                firstRun = false;
                hideContainer = false;
                MakeAllRDataSource();
                StateHasChanged();
                return;
            }
            if (RConditions.Any() && refreshRDataSource)
            {
                refreshRDataSource = false;
                MakeAllRDataSource();
                StateHasChanged();
                return;
            }
            if (requireRender)
            {

                requireRender = false;
                StateHasChanged();
                return;
            }

            RenderCompleted?.Invoke();

        }

        protected void Add()
        {
            var x = new Pinhua2.Data.Models.view_AllOrdersPay
            {
                RecordId = 1987,
                业务类型 = "test",
                个数 = 1987,
                交期 = new DateTime(1987, 9, 22),
                仓 = "test",
                别名 = "test",
                日期 = new DateTime(1987, 9, 22)

            };

            DataSource.Add(default);
            MakeOneRDataSource(default);
        }

        protected void Remove()
        {
            var item = DataSource.FirstOrDefault();
            DataSource.Remove(item);
            var ritem = RDataSource.Find(m => m.Data.Equals(item));
            RDataSource.Remove(ritem);
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
                SelectedRows = new HashSet<TItem>(DataSource);
            }
            else
            {
                SelectedRows = new HashSet<TItem>();
            }

            RefreshSelectAllStatus();
        }

        protected void ChangeRowStatus(Status status, TItem row)
        {
            if (status == Status.Checked)
            {
                if (IsSingleSelect)
                {
                    SelectedRows = new HashSet<TItem>();
                }
                SelectedRows.Add(row);
            }
            else
            {
                SelectedRows.Remove(row);
            }
            RefreshSelectAllStatus();
        }

        protected void InverTItemStatus(TItem row)
        {
            ChangeRowStatus(SelectedRows.Contains(row) ? Status.UnChecked : Status.Checked, row);
        }

        protected void RowClicked(TItem row)
        {
            if (IsClickToSelect)
            {
                InverTItemStatus(row);
            }
        }
    }
}
