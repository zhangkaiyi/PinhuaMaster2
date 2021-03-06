﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Pinhua2.Common.Attributes;

namespace Pinhua2.Web.BlazorComponents.RTable
{
    public class ReflectionTable<TDataSource>
    {
        public List<RTableCondition<TDataSource>> Conditions { get; set; } = new List<RTableCondition<TDataSource>>();
        public List<ReflectionRow<TDataSource>> Rows { get; set; } = new List<ReflectionRow<TDataSource>>();
        public List<ReflectionCol<TDataSource>> Cols { get; set; } = new List<ReflectionCol<TDataSource>>();
        public Dictionary<string, ReflectionCol<TDataSource>> ColsNamed { get; set; } = new Dictionary<string, ReflectionCol<TDataSource>>();
    }
}
