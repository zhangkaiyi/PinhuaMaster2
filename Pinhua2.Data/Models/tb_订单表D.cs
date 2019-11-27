using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_订单表D")]
    public partial class tb_订单表D : _BaseProductDetail
    {
        public decimal? 库存 { get; set; }
        public string 单位 { get; set; }
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        public decimal? 最新价 { get; set; }
        public DateTime? 新价日期 { get; set; }
        public string 品牌 { get; set; }
        public string 状态 { get; set; }
        public string 质保 { get; set; }
    }
}
