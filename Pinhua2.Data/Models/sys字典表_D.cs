using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public partial class sys字典表_D : _BaseTableDetail
    {
        public decimal? RN { get; set; }
        public string 名称 { get; set; }
        public string 描述 { get; set; }
        public string 代码 { get; set; }
        public string 字典名 { get; set; }
        public string 组 { get; set; }
    }
}
