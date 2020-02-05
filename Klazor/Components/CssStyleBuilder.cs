﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klazor
{
    /// <summary>
    /// CSS 样式构建器
    /// </summary>
    public class CssStyleBuilder : HtmlPropertyBuilder
    {
        public override string ToString()
        {
            return base.ToString(";");
        }
    }
}
