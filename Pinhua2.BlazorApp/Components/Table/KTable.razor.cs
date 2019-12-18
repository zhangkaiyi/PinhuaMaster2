﻿using BlazorComponentUtilities;
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
        protected bool secondRun = true;
        protected bool hideContainer = true;
        protected bool refreshRDataSource = false;
        public ElementReference Container { get; set; }
        protected Status selectAllStatus;
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

        public List<KDataSource<TItem>> RDataSource = new List<KDataSource<TItem>>();
        public List<KTableCondition<TItem>> RConditions = new List<KTableCondition<TItem>>();

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
            MakeFirstRDataSource();
            RefreshSelectAllStatus();
        }

        protected void MakeAllRDataSource()
        {
            RDataSource = new List<KDataSource<TItem>>();
            foreach (var row in DataSource)
            {
                var rRow = new KDataSource<TItem>();
                rRow.Data = row;
                rRow.RData = MyMark.Parse(row).Select(m =>
                new ReflectedCell<TItem>
                {
                    Model = m
                }.ApplyConditions(RConditions)).ToList();

                RDataSource.Add(rRow);
            }
        }

        protected void MakeFirstRDataSource()
        {
            RDataSource = new List<KDataSource<TItem>>();
            foreach (var row in DataSource)
            {
                var rRow = new KDataSource<TItem>();
                rRow.Data = row;
                var i = DataSource.IndexOf(row);
                if (i == 0)
                {
                    rRow.RData = MyMark.Parse(row).Select(m =>
                    new ReflectedCell<TItem>
                    {
                        Model = m
                    }.ApplyConditions(RConditions)).ToList();
                }
                else
                {
                    rRow.RData = MyMark.Parse(row).Select(m =>
                    new ReflectedCell<TItem>
                    {
                        Model = m
                    }).ToList();
                }
                RDataSource.Add(rRow);
            }
        }

        protected void MakeOneRDataSource(TItem row)
        {
            var rRow = new KDataSource<TItem>();
            rRow.Data = row;
            rRow.RData = (from m in MyMark.Parse(row)
                          select new ReflectedCell<TItem>
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
                // 第一次执行，执行if语句true的部分
                firstRun = false;
                hideContainer = false;
                MakeFirstRDataSource();
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

            RenderCompleted?.Invoke();

        }

        public void Add(TItem item)
        {

            DataSource.Add(item);
            MakeOneRDataSource(item);
        }

        public void Remove(TItem item)
        {
            DataSource.Remove(item);
            var ritem = RDataSource.Find(m => m.Data.Equals(item));
            RDataSource.Remove(ritem);
        }

        public void RemoveAt(int index)
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

        public void ChangeAllStatus(Status status)
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

        public void ChangeRowStatus(Status status, TItem row)
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