using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pinhua2.Data.Models
{
    public interface _IBaseTable_Product
    {
        string 品号 { get; set; }
        string 品名 { get; set; }
        string 别名 { get; set; }
        string 型号 { get; set; }
        string 规格 { get; set; }
        decimal? 长度 { get; set; }
        decimal? 宽度 { get; set; }
        decimal? 高度 { get; set; }
        decimal? 面厚 { get; set; }
    }
    public partial class _BaseProductMain : _BaseTableMain, _IBaseTable_Product
    {
        [CustomDisplay(1.1)]
        [MyOrder(1.1)]
        public string 品号 { get; set; }
        [CustomDisplay(1.2)]
        [MyOrder(1.2)]
        public string 品名 { get; set; }
        [CustomDisplay(1.3)]
        [MyOrder(1.3)]
        public string 别名 { get; set; }
        [CustomDisplay(1.4)]
        [MyOrder(1.4)]
        public string 型号 { get; set; }
        [CustomDisplay(1.5)]
        [MyOrder(1.5)]
        public string 规格 { get; set; }
        [CustomDisplay(2.1)]
        [MyHiddenRef]
        [MyOrder(2.1)]
        [MyHiddenField]
        public decimal? 长度 { get; set; }
        [CustomDisplay(2.2)]
        [MyHiddenRef]
        [MyOrder(2.2)]
        [MyHiddenField]
        public decimal? 宽度 { get; set; }
        [CustomDisplay(2.3)]
        [MyHiddenRef]
        [MyOrder(2.3)]
        [MyHiddenField]
        public decimal? 高度 { get; set; }
        [CustomDisplay(2.4)]
        [MyHiddenRef]
        [MyOrder(2.4)]
        [MyHiddenField]
        public decimal? 面厚 { get; set; }
    }

    public partial class _BaseProductDetail : _BaseTableDetail, _IBaseTable_Product
    {
        [CustomDisplay(1.1)]
        [MyOrder(1.1)]
        public string 品号 { get; set; }

        [CustomDisplay(1.2)]
        [MyOrder(1.2)]
        public string 品名 { get; set; }

        [CustomDisplay(1.3)]
        [MyOrder(1.3)]
        public string 别名 { get; set; }

        [CustomDisplay(1.4)]
        [MyOrder(1.4)]
        public string 型号 { get; set; }

        [CustomDisplay(1.5)]
        [MyOrder(1.5)]
        public string 规格 { get; set; }

        [CustomDisplay(2.1)]
        [MyOrder(2.1)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit, MyHiddenDelete]
        [MyHiddenRef]
        [MyHiddenField]
        public decimal? 长度 { get; set; }

        [CustomDisplay(2.2)]
        [MyOrder(2.2)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit, MyHiddenDelete]
        [MyHiddenRef]
        [MyHiddenField]
        public decimal? 宽度 { get; set; }

        [CustomDisplay(2.3)]
        [MyOrder(2.3)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit, MyHiddenDelete]
        [MyHiddenRef]
        [MyHiddenField]
        public decimal? 高度 { get; set; }

        [CustomDisplay(2.4)]
        [MyOrder(2.4)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit, MyHiddenDelete]
        [MyHiddenRef]
        [MyHiddenField]
        public decimal? 面厚 { get; set; }
    }
}
