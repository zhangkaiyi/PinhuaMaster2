using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pinhua2.Data.Models
{
    public partial class _BaseTableMain
    {
        [Key]
        public int RecordId { get; set; }
        public int? CreateUser { get; set; }
        public int? CreateOrg { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? EditingUser { get; set; }
        public int? LastEditUser { get; set; }
        public DateTime? LastEditTime { get; set; }
        public int? ReportStatus { get; set; }
        public int? LockStatus { get; set; }
        public string WorkflowStatus { get; set; }
    }

    public partial class _BaseTableDetail
    {
        [Key]
        public int Idx { get; set; }
        public int RecordId { get; set; }
        public int? Sequence { get; set; }
    }
}
