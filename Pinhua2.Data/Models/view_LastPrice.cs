using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public class view_LastPrice
    {
        public int? RecordId { get; set; }
        public string 业务类型 { get; set; }
        public string 往来号 { get; set; }
        public string 品号 { get; set; }
        public DateTime? 日期 { get; set; }
        public decimal? 最高价 { get; set; }
        public decimal? 最低价 { get; set; }
    }
}
