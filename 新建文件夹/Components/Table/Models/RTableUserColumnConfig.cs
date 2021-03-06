﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Klazor
{
    public class RTableUserColumnConfig<TRow>
    {
        public KTableUserColumn<TRow> Column { get; set; }
        public string Text { get; set; }
        public int? Width { get; set; }
        public string Property { get; set; }
        public Func<TRow, object> Eval { get; set; }
        public bool IsCheckBox { get; set; }
        public RenderFragment<TRow> Template { get; set; }
    }
}
