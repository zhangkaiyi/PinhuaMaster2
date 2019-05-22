using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_字典表D")]
    public partial class tb_字典表D : _BaseTableDetail
    {
        public string 字典名 { get; set; }
        public int? 序 { get; set; }
        public string 代码 { get; set; }
        public string 名称 { get; set; }
        public string 描述 { get; set; }
        public string 组 { get; set; }
    }
}
