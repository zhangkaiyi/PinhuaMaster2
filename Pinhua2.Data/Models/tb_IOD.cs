using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_IOD")]
    public partial class tb_IOD : _BaseProductDetail
    {
        public string 订单号 { get; set; }
        public string 行号 { get; set; }
        public string 品牌 { get; set; }
        public string 单位 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        public decimal? 质保 { get; set; }
        public string 批次 { get; set; }
        public string 条码 { get; set; }
        public string 库位 { get; set; }
        public string 库存 { get; set; }
        public string 仓 { get; set; }
        public decimal? 发 { get; set; }
        public DateTime? 日期 { get; set; }
        public decimal? 收 { get; set; }
        public decimal? 计划数 { get; set; }
        public decimal? 已完数 { get; set; }
        public string 版本号 { get; set; }
        public string 日期唛 { get; set; }
    }
}
