using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public class sysIO : _BaseTableMain
    {
        public string 单号 { get; set; }
        public DateTime? 日期 { get; set; }
        public string 制单 { get; set; }
        public string 仓 { get; set; }
        public string 订单号 { get; set; }
        public string 往来 { get; set; }
        public string 往来号 { get; set; }
        public string 备注 { get; set; }
        public string 类型 { get; set; }
        public decimal? 退单 { get; set; }
        public string 物流单号 { get; set; }
        public string 保修类型 { get; set; }
    }
}
