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
        [CustomDisplay(1)]
        public string 品号 { get; set; }
        [CustomDisplay(1)]
        public string 品名 { get; set; }
        [CustomDisplay(1)]
        public string 别名 { get; set; }
        [CustomDisplay(1)]
        public string 型号 { get; set; }
        [CustomDisplay(1)]
        public string 规格 { get; set; }
        [CustomDisplay(1)]
        [MyHiddenRef]
        public decimal? 长度 { get; set; }
        [CustomDisplay(1)]
        [MyHiddenRef]
        public decimal? 宽度 { get; set; }
        [CustomDisplay(1)]
        [MyHiddenRef]
        public decimal? 高度 { get; set; }
        [CustomDisplay(1)]
        [MyHiddenRef]
        public decimal? 面厚 { get; set; }
    }

    public partial class _BaseProductDetail : _BaseTableDetail, _IBaseTable_Product
    {
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 别名 { get; set; }
        public string 型号 { get; set; }
        public string 规格 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 长度 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 宽度 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 高度 { get; set; }
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 面厚 { get; set; }
    }
}
