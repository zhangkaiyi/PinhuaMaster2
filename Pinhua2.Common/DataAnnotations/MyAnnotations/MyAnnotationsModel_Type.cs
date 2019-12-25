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

        public bool IsDatetime
        {
            get
            {
                if (_propertyInfo == null)
                    return false;
                else
                {
                    var propType = _propertyInfo.PropertyType;
                    var dtType1 = typeof(DateTime);
                    var dtType2 = typeof(DateTime?);
                    return (propType == dtType1) || propType == dtType2;
                }
            }
        }
        public bool IsDecimal
        {
            get
            {
                if (_propertyInfo == null)
                    return false;
                else
                {
                    var propType = _propertyInfo.PropertyType;
                    var dtType1 = typeof(decimal);
                    var dtType2 = typeof(decimal?);
                    return (propType == dtType1) || propType == dtType2;
                }
            }
        }

        #endregion
    }
}