using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pinhua2.Data.Models
{
    public interface _IBaseTableMain
    {
        int RecordId { get; set; }
        string CreateUser { get; set; }
        DateTime? CreateTime { get; set; }
        string LastEditUser { get; set; }
        DateTime? LastEditTime { get; set; }
        int? ReportStatus { get; set; }
        int? LockStatus { get; set; }
        Guid Guid { get; set; }
    }
    public partial class _BaseTableMain : _IBaseTableMain
    {
        [Key]
        public int RecordId { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public string LastEditUser { get; set; }
        public DateTime? LastEditTime { get; set; }
        public int? ReportStatus { get; set; }
        public int? LockStatus { get; set; }
        public Guid Guid { get; set; }
    }

    public interface _IBaseTableDetail
    {
        int Idx { get; set; }
        int? RecordId { get; set; }
        int? Sequence { get; set; }
        Guid Guid { get; set; }
    }

    public partial class _BaseTableDetail : _IBaseTableDetail
    {
        [Key]
        public int Idx { get; set; }
        public int? RecordId { get; set; }
        public int? Sequence { get; set; }
        public Guid Guid { get; set; }

    }
}
