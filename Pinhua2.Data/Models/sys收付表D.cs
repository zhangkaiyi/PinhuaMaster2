using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_收付表D")]
    public partial class tb_收付表D:_BaseTableDetail
    {
        public string 子单号 { get; set; }
        public decimal? 数量 { get; set; }
        public decimal? 金额 { get; set; }
        public decimal? 收发数 { get; set; }
        public decimal? 收发额 { get; set; }
        public decimal? 已收付款数 { get; set; }
        public decimal? 已收付款额 { get; set; }
        public decimal? 本次收数 { get; set; }
        public decimal? 本次收额 { get; set; }
        public decimal? 本次付数 { get; set; }
        public decimal? 本次付额 { get; set; }
        public string 备注 { get; set; }
        public string 描述 { get; set; }
        public string 单位 { get; set; }
        public decimal? 可收付款额 { get; set; }
        public decimal? 待收付款额 { get; set; }
    }
}
