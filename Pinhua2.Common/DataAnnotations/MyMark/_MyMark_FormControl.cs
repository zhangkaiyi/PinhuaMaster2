using Pinhua2.Common.MyAnnotations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TagHelpers;

namespace Pinhua2.Common.Attributes
{
    public partial class MyMarkModel
    {
        #region 各种属性

        public string FormControlPlaceholder
        {
            get
            {
                if (_propertyInfo == null)
                    return string.Empty;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyFormControlAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as MyFormControlAttribute).Placeholder;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        #endregion
    }
}