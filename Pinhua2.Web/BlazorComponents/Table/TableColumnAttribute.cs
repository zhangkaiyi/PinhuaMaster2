using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.BlazorComponents.Table
{
    public class TableColumnAttribute : Attribute
    {
        public string Text { get; set; }
        public int Width { get; set; }
    }
}
