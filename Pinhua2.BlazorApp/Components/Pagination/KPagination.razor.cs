using BlazorComponentUtilities;
using Klazor.Util;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Klazor
{
    public partial class KPagination : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UnknownParameters { get; set; }
        protected string Classname =>
         new CssBuilder("pagination")
             .AddClass($"pagination-{Size.ToDescriptionString()}", Size != Size.None)
             .AddClass(GetAlignment())
             .AddClass(Class)
         .Build();

        [Parameter] public Size Size { get; set; } = Size.None;
        [Parameter] public Alignment Alignment { get; set; } = Alignment.Left;
        [Parameter] public string Class { get; set; }
        [Parameter] public string Style { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [Parameter] public int Total { get; set; } = 100;
        /// <summary>
        /// 每页条数
        /// </summary>
        [Parameter]public int PageSize { get; set; } = 20;
        /// <summary>
        /// 当前页码，从1开始
        /// </summary>
        [Parameter] public int CurrentPage { get; set; } = 1;
        /// <summary>
        /// 最大显示的页码数
        /// </summary>
        [Parameter]
        public int ShowPageCount { get; set; } = 7;
        /// <summary>
        /// 当前页码变化时触发
        /// </summary>
        [Parameter] public Func<int, Task> CurrentPageChanged { get; set; }
        /// <summary>
        /// 当前最大显示的页码数变化时触发
        /// </summary>
        [Parameter] public EventCallback<int> PageCountChanged { get; set; }

        internal int pageCount;

        private string GetAlignment()
        {
            if (Alignment == Alignment.Center) { return "justify-content-center"; }
            if (Alignment == Alignment.Right) { return "justify-content-end"; }
            return null;
        }
    }
}
