﻿using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public class RTableColumnConfig
    {
        public Expression<Func<RTableColumnConfig, bool>> Predicate { get; set; }
        public Func<RTableColumnConfig, bool> Eval { get; set; }
        public MyMarkModel Model { get; set; }
        public bool IsHidden { get; set; } = false;
        public IList<string> ColumnClasses { get; set; } = new List<string>();
        public RTableValueType ValueType { get; set; } = RTableValueType.Text;
        public string ValueFormat { get; set; } = string.Empty;
    }

    public class RTableAutoColumnConfig<TRow>
    {
        public List<RTableCondition<TRow>> Conditions { get; set; }
        public List<MyMarkModel> Row { get; set; }
    }
}
