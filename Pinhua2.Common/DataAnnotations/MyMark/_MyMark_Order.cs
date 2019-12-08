using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TagHelpers;

namespace Pinhua2.Common.Attributes
{
    public partial class  MyMarkModel
    {

        #region 各种属性
        public double Order
        {
            get
            {
                if (_propertyInfo == null)
                    return 100;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(CustomDisplayAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as CustomDisplayAttribute).Order;
                }
                else
                {
                    return 100;
                }
            }
        }

        #endregion
    }
}