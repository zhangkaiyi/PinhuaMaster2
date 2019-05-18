using System;
using System.Collections.Generic;

namespace Pinhua2.Data.Models
{
    public partial class sys开票表 : _BaseTableDetail
    {
        public string 往来号 { get; set; }
        public string 发票抬头 { get; set; }
        public string 账号 { get; set; }
        public string 税号 { get; set; }
    }
}
