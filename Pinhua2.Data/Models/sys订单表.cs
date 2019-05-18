using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public partial class sys订单表: _BaseTableMain
    {
        public string 单号 { get; set; }
        public string 往来单号 { get; set; }
        public string 业务类型 { get; set; }
        public string 仓 { get; set; }
        public DateTime? 日期 { get; set; }
        public DateTime? 交期 { get; set; }
        public string 备注 { get; set; }
        public string 制单 { get; set; }
        public string 往来 { get; set; }
        public string 往来号 { get; set; }
        public string 报价单 { get; set; }
        public decimal? 应收 { get; set; }
        public decimal? 应付 { get; set; }
    }
}
