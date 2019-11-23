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
        [MyHiddenCreate, MyHiddenEdit]
        [MySysColumn]
        public int RecordId { get; set; }

        [CustomDisplay(ForIndex = false)]
        [MySysColumn]
        [MyHiddenIndex]
        public string CreateUser { get; set; }

        [CustomDisplay(ForIndex = false)]
        [MySysColumn]
        [MyHiddenIndex]
        public DateTime? CreateTime { get; set; }

        [CustomDisplay(ForIndex = false)]
        [MySysColumn]
        [MyHiddenIndex]
        public string LastEditUser { get; set; }

        [CustomDisplay(ForIndex = false)]
        [MySysColumn]
        [MyHiddenIndex]
        public DateTime? LastEditTime { get; set; }

        [CustomDisplay(ForIndex = false)]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenDetails, MyHiddenEdit]
        [MySysColumn]
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
        [MyHiddenIndex, MyHiddenCreate, MyHiddenEdit]
        public int Idx { get; set; }

        [CustomDisplay(10, ForIndex = false)]
        public int? RN { get; set; }

        [CustomDisplay]
        [MyHiddenIndex, MyHiddenCreate, MyHiddenEdit]
        public int? RecordId { get; set; }

        [CustomDisplay(10)]
        public string 子单号 { get; set; }
    }
}
