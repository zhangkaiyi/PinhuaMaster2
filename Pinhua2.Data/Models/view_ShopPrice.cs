using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public class view_ShopPrice
    {
        public string 品号 { get; set; }
        public string 品名 { get; set; }
        public string 型号 { get; set; }
        public string 别名 { get; set; }
        public decimal? 采购价 { get; set; }
        public decimal? 批发价 { get; set; }
        public decimal? 零售价 { get; set; }
    }
}
