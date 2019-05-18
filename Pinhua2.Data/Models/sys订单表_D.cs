﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public partial class sys订单表_D : _BaseTableDetail
    {
        public string 行号 { get; set; }
        public string 子单号 { get; set; }
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 规格 { get; set; }
        public decimal? 库存 { get; set; }
        public string 单位 { get; set; }
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
