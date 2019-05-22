using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_往来表_地址")]
    public partial class tb_往来表_地址 : _BaseTableDetail
    {
        public string 往来号 { get; set; }
        public string 地址 { get; set; }
        public string 联系人 { get; set; }
        public string 电话 { get; set; }
    }
}
