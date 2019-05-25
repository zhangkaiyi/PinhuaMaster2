using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_证照表")]
    public partial class tb_证照表: _BaseTableMain
    {
        public string 品号 { get; set; }
        public string 文件 { get; set; }
        public int? 文件A { get; set; }
        public string 图片 { get; set; }
        public int? 图片I { get; set; }
        public string 说明 { get; set; }
        public DateTime? 有效日 { get; set; }
        public string 是否预警 { get; set; }
        public string 登记人 { get; set; }
        public DateTime? 登记日期 { get; set; }
        public string 档案号 { get; set; }
    }
}
