using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_字典表")]
    public partial class tb_字典表: _BaseTableMain
    {
        public string 字典号 { get; set; }
        public string 字典名 { get; set; }
        public string 组号 { get; set; }
        public string 组名 { get; set; }
    }
}
