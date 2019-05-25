using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_收付表")]
    public partial class tb_收付表: _BaseTableMain
    {
        public string 类型 { get; set; }
        public string 往来 { get; set; }
        public string 往来号 { get; set; }
        public decimal? 收 { get; set; }
        public decimal? 付 { get; set; }
        public string 单号 { get; set; }
        public DateTime? 日期 { get; set; }
        public string 制单 { get; set; }
        public string 备注 { get; set; }
        public decimal? 分配 { get; set; }
        public string 发票号 { get; set; }
    }
}
