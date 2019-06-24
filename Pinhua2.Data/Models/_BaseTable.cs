using Pinhua2.Common.Attributes;
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
        bool? IsDeleted { get; set; }
    }
    public partial class _BaseTableMain : _IBaseTableMain
    {
        [Key]
        [CustomDisplay(IsRendered = false, ForIndex = true)]
        public int RecordId { get; set; }

        [CustomDisplay(ForIndex = false)]
        public string CreateUser { get; set; }

        [CustomDisplay(ForIndex = false)]
        public DateTime? CreateTime { get; set; }

        [CustomDisplay(ForIndex = false)]
        public string LastEditUser { get; set; }

        [CustomDisplay(ForIndex = false)]
        public DateTime? LastEditTime { get; set; }

        [CustomDisplay(ForIndex = false)]
        public bool? IsDeleted { get; set; }
    }

    public interface _IBaseTableDetail
    {
        int Idx { get; set; }
        int? RecordId { get; set; }
        string 子单号 { get; set; }
        int? RN { get; set; }
    }

    public partial class _BaseTableDetail : _IBaseTableDetail
    {
        [Key]
        [CustomDisplay(ForIndex = false)]
        public int Idx { get; set; }

        [CustomDisplay(10, ForIndex = false)]
        public int? RN { get; set; }

        [CustomDisplay]
        public int? RecordId { get; set; }

        [CustomDisplay(10)]
        public string 子单号 { get; set; }
    }
}
