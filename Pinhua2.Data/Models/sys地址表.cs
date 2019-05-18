using System;
using System.Collections.Generic;

namespace Pinhua2.Data.Models
{
    public partial class sys地址表 : _BaseTableDetail
    {
        public string 往来号 { get; set; }
        public string 地址 { get; set; }
        public string 联系人 { get; set; }
        public string 电话 { get; set; }
    }
}
