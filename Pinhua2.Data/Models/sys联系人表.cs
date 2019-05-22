using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    [Table("tb_往来表_联系人")]
    public partial class tb_往来表_联系人 : _BaseTableDetail
    {
        public string 往来号 { get; set; }
        public string 联系人 { get; set; }
        public string 部门 { get; set; }
        public string 职位 { get; set; }
        public string 电话 { get; set; }
        public string 手机 { get; set; }
        public string Email { get; set; }
        public string 传真 { get; set; }
        public string Qq { get; set; }
        public string 备注 { get; set; }
    }
}
