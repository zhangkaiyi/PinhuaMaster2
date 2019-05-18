using System;
using System.Collections.Generic;

namespace Pinhua2.Data.Models
{
    public partial class sys联系人表 : _BaseTableDetail
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
