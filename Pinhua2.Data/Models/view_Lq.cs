using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public class view_Lq
    {
        public string 品号 { get; set; }
        public string 库位 { get; set; }
        public decimal? 库存 { get; set; }
    }
}
