using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Common
{
    public class ModelHelper
    {
        static public void CompleteMainOnCreate(_IBaseTableMain dstMain)
        {
            dstMain.CreateTime = DateTime.Now;
            dstMain.CreateUser = dstMain.CreateUser ?? "张凯译";
            dstMain.Guid = Guid.NewGuid();
        }
        static public void CompleteDetailOnCreate(_IBaseTableMain src, _IBaseTableDetail dst)
        {
            dst.RecordId = src.RecordId;
            dst.Guid = src.Guid;
        }
        static public void CompleteDetailOnUpdate(_IBaseTableMain src, _IBaseTableDetail dst)
        {
            dst.RecordId = src.RecordId;
            dst.Guid = src.Guid;
        }
    }
}
