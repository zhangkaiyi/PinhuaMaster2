using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pinhua2.Data.Models
{
    [Table("tb_商品表")]
    public class tb_商品表 : _BaseTableMain
    {
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 型号 { get; set; }
        public string 拼音码 { get; set; }
        public string 规格 { get; set; }
        public decimal? 长度 { get; set; }
        public decimal? 宽度 { get; set; }
        public decimal? 高度 { get; set; }
        public decimal? 面厚 { get; set; }
        public string 库位 { get; set; }
        public string 单位 { get; set; }
        public string 分类1 { get; set; }
        public string 分类2 { get; set; }
        public decimal? 安全库存 { get; set; }
        public string 状态 { get; set; }
        public string 大类 { get; set; }
        public string 别名 { get; set; }
        public string 材质 { get; set; }
        public string 表面处理 { get; set; }
        public string 换算单位 { get; set; }
        public decimal? 换算系数 { get; set; }
        public decimal? 单重 { get; set; }
        public string 色号 { get; set; }
        public string 客户号 { get; set; }
        public string 客户 { get; set; }
        public decimal? 销售价 { get; set; }
        public decimal? 指定销售价 { get; set; }
        public string 供应商号 { get; set; }
        public string 供应商 { get; set; }
        public decimal? 采购价 { get; set; }
        public decimal? 最新采购价 { get; set; }
        public decimal? 采购周期 { get; set; }
        public string 客户料号 { get; set; }
        public string 计算公式 { get; set; }
        public string 档案号 { get; set; }
        public string 是否共用 { get; set; }
        public string 上级品号 { get; set; }
        public string 版本号 { get; set; }
        public string 条码 { get; set; }
        public string 备注 { get; set; }
        public string 图片 { get; set; }
        public int? 图片I { get; set; }
        public string 品牌 { get; set; }
        public string 链接 { get; set; }
        public string 是否采购 { get; set; }
        public string 是否销售 { get; set; }
        public string 是否存储 { get; set; }
        public string 上级品名 { get; set; }
        public decimal? 质保 { get; set; }
    }
}
