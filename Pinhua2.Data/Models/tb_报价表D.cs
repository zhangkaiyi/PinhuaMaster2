using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_报价表D")]
    public partial class tb_报价表D:_BaseTableDetail
    {
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 别名 { get; set; }
        public string 型号 { get; set; }
        public string 规格 { get; set; }
        public decimal? 库存 { get; set; }
        public string 单位 { get; set; }
        public decimal? 个数 { get; set; }
        public decimal? 数量 { get; set; }
        public decimal? 单价 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 税率 { get; set; }
        public string 备注 { get; set; }
        public decimal? 上次价 { get; set; }
        public DateTime? 上次日期 { get; set; }
        public string 品牌 { get; set; }
        public string 状态 { get; set; }
    }
}
