using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public class view_AllOrders
    {
        public string 单号 { get; set; }
        public DateTime? 日期 { get; set; }
        public string 制单 { get; set; }
        public string 仓 { get; set; }
        public string 往来 { get; set; }
        public string 往来号 { get; set; }
        public string 备注 { get; set; }
        public string 业务类型 { get; set; }
        public DateTime? 交期 { get; set; }
        public string 子单号 { get; set; }
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 规格 { get; set; }
        public string 单位 { get; set; }
        public decimal? 个数 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 状态 { get; set; }
        public int? RecordId { get; set; }
        public string 品牌 { get; set; }
        public string 质保 { get; set; }
    }
}
