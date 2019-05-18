using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;

namespace Pinhua2.Data.Models
{
    public partial class sys字典表: _BaseTableMain
    {
        public string 字典名 { get; set; }
        public string 组 { get; set; }
        public string 创建人 { get; set; }
        public DateTime? 创建日 { get; set; }
    }
}
