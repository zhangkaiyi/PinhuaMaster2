using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pinhua2.Common.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pinhua2.Data.Models
{
    public class view_AllOrders
    {
        [CustomDisplay(10)]
        public string 单号 { get; set; }
        [CustomDisplay(70)]
        [JsonConverter(typeof(MyDateConverter))]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public DateTime? 日期 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 制单 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 仓 { get; set; }
        [CustomDisplay(20)]
        public string 往来 { get; set; }
        [CustomDisplay(19)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 往来号 { get; set; }
        public string 备注 { get; set; }
        [CustomDisplay(15)]
        public string 业务类型 { get; set; }
        [CustomDisplay(71)]
        [JsonConverter(typeof(MyDateConverter))]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public DateTime? 交期 { get; set; }
        [CustomDisplay(11)]
        public string 子单号 { get; set; }
        [CustomDisplay(49)]
        public string 品号 { get; set; }
        [CustomDisplay(50)]
        public string 型号 { get; set; }
        [CustomDisplay(51)]
        public string 品名 { get; set; }
        [CustomDisplay(55)]
        public string 规格 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 长度 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 宽度 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 高度 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 面厚 { get; set; }
        [CustomDisplay(58)]
        public string 单位 { get; set; }
        [CustomDisplay(56)]
        public decimal? 个数 { get; set; }
        [CustomDisplay(57)]
        public decimal? 数量 { get; set; }
        [CustomDisplay(59)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 单价 { get; set; }
        [CustomDisplay(60)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 金额 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 税率 { get; set; }
        public string 状态 { get; set; }
        [CustomDisplay(5)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public int? RecordId { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 品牌 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public string 质保 { get; set; }
    }

    public class view_AllOrders2_order
    {
        [CustomDisplay(5)]
        public int? RecordId { get; set; }
        [CustomDisplay(10)]
        public string 单号 { get; set; }

        [CustomDisplay(48)]
        public string 子单号 { get; set; }
        [CustomDisplay(19)]
        public string 往来号 { get; set; }
        [CustomDisplay(20)]
        public string 往来 { get; set; }
        public string 备注 { get; set; }
        [CustomDisplay(15)]
        public string 业务类型 { get; set; }

        [CustomDisplay(70)]
        [JsonConverter(typeof(MyDateConverter))]
        public DateTime? 日期 { get; set; }

        [CustomDisplay(71)]
        [JsonConverter(typeof(MyDateConverter))]
        public DateTime? 交期 { get; set; }

        [CustomDisplay(49)]
        public string 品号 { get; set; }
        [CustomDisplay(56)]
        public decimal? 个数 { get; set; }
        [CustomDisplay(59)]
        public decimal? 单价 { get; set; }
        [CustomDisplay(60)]
        public decimal? 金额 { get; set; }
        public string 制单 { get; set; }
        public string 状态 { get; set; }
    }
    public class view_AllOrders2
    {
        public view_AllOrders2_order Order { get; set; }
        public tb_商品表 Product { get; set; }

        
    }

}
