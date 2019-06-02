using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public class view_OrderIO
    {
        public decimal? 收 { get; set; }
        public decimal? 发 { get; set; }
        public string 子单号 { get; set; }
    }
}
