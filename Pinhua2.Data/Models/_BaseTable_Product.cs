﻿using Pinhua2.Common.Attributes;
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
        public string 品号 { get; set; }
        [CustomDisplay(1.2)]
        public string 品名 { get; set; }
        [CustomDisplay(1.3)]
        public string 别名 { get; set; }
        [CustomDisplay(1.4)]
        public string 型号 { get; set; }
        [CustomDisplay(1.5)]
        public string 规格 { get; set; }
        [CustomDisplay(2.1)]
        [MyHiddenRef]
        public decimal? 长度 { get; set; }
        [CustomDisplay(2.2)]
        [MyHiddenRef]
        public decimal? 宽度 { get; set; }
        [CustomDisplay(2.3)]
        [MyHiddenRef]
        public decimal? 高度 { get; set; }
        [CustomDisplay(2.4)]
        [MyHiddenRef]
        public decimal? 面厚 { get; set; }
    }

    public partial class _BaseProductDetail : _BaseTableDetail, _IBaseTable_Product
    {
        [CustomDisplay(1.1)]
        public string 品号 { get; set; }

        [CustomDisplay(1.2)]
        public string 品名 { get; set; }

        [CustomDisplay(1.3)]
        public string 别名 { get; set; }

        [CustomDisplay(1.4)]
        public string 型号 { get; set; }

        [CustomDisplay(1.5)]
        public string 规格 { get; set; }

        [CustomDisplay(2.1)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 长度 { get; set; }

        [CustomDisplay(2.2)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 宽度 { get; set; }

        [CustomDisplay(2.3)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 高度 { get; set; }

        [CustomDisplay(2.4)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        public decimal? 面厚 { get; set; }
    }
}
