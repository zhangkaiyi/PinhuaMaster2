﻿using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public partial class RTableHiddenCondition<TRow> : RTableCondition<TRow>
    {
        public bool IsHidden { get; set; } = true;

    }
}
