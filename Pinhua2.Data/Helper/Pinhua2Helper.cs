using Newtonsoft.Json.Linq;
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
        static public JObject JObjectFromMerge(params object[] objects)
        {
            var jObject = new JObject();
            foreach(var obj in objects)
            {
                var json = JObject.FromObject(obj);
                jObject.Merge(json);
            }
            return jObject;
        }
        static public JArray JsonMergeArray(IList<object[]> objects)
        {
            var jArray = new JArray();
            foreach (var objs in objects)
            {
                jArray.Add(JObjectFromMerge(objs));
            }
            return jArray;
        }
    }
}
