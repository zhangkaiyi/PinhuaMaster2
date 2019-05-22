using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_往来表_开票")]
    public partial class tb_往来表_开票 : _BaseTableDetail
    {
        public string 往来号 { get; set; }
        public string 发票抬头 { get; set; }
        public string 账号 { get; set; }
        public string 税号 { get; set; }
    }
}
