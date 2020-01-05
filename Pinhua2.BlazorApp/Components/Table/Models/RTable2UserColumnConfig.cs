using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Klazor
{
    public class KTable2ColumnSetting
    {
        public KTable2Column Column { get; set; }
        public string Field { get; set; }
        public string Text { get; set; }
        public int? Width { get; set; }
        public bool IsCheckBox { get; set; }
        public RenderFragment<object> Template { get; set; }
    }
}
