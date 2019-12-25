using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TagHelpers;

namespace Pinhua2.Common.MyAnnotations
{
    public partial class MyAnnotationsModel
    {

        #region 各种属性

        //public string Name
        //{
        //    get
        //    {
        //        if (_propertyInfo == null)
        //            return string.Empty;

        //        var attrs = _propertyInfo.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
        //        if (attrs?.Length > 0)
        //        {
        //            return (attrs[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
        //        }
        //        else
        //        {
        //            return _propertyInfo.Name;
        //        }
        //    }
        //}

        //public string RawName
        //{
        //    get
        //    {
        //        return _propertyInfo?.Name ?? string.Empty;
        //    }
        //}
        #endregion
    }
}