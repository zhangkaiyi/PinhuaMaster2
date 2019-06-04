using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pinhua2.Common.Attributes;

namespace Pinhua2.Data.Models
{
    public class view_AllOrders
    {
        [CustomDisplay(10)]
        public string 单号 { get; set; }
        [CustomDisplay(70)]
        public DateTime? 日期 { get; set; }
        public string 制单 { get; set; }
        public string 仓 { get; set; }
        [CustomDisplay(20)]
        public string 往来 { get; set; }
        [CustomDisplay(19)]
        public string 往来号 { get; set; }
        public string 备注 { get; set; }
        [CustomDisplay(15)]
        public string 业务类型 { get; set; }
        [CustomDisplay(71)]
        public DateTime? 交期 { get; set; }
        [CustomDisplay(48)]
        public string 子单号 { get; set; }
        [CustomDisplay(49)]
        public string 品号 { get; set; }
        [CustomDisplay(50)]
        public string 型号 { get; set; }
        [CustomDisplay(51)]
        public string 品名 { get; set; }
        [CustomDisplay(55)]
        public string 规格 { get; set; }
        [CustomDisplay(58)]
        public string 单位 { get; set; }
        [CustomDisplay(56)]
        public decimal? 个数 { get; set; }
        [CustomDisplay(57)]
        public decimal? 数量 { get; set; }
        [CustomDisplay(59)]
        public decimal? 单价 { get; set; }
        [CustomDisplay(60)]
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 状态 { get; set; }
        [CustomDisplay(5)]
        public int? RecordId { get; set; }
        public string 品牌 { get; set; }
        public string 质保 { get; set; }
    }
}
