using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Data.Helper
{
    public class Pinhua2Helper
    {
        static public void CompleteMainOnCreate(_IBaseTableMain dstMain)
        {
            dstMain.CreateTime = DateTime.Now;
            dstMain.CreateUser = dstMain.CreateUser ?? "张凯译";
            dstMain.Guid = Guid.NewGuid();
        }
        static public void CompleteMainOnEdit(_IBaseTableMain dstMain)
        {
            dstMain.LastEditTime = DateTime.Now;
            dstMain.LastEditUser = dstMain.LastEditUser ?? "张凯译";
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
