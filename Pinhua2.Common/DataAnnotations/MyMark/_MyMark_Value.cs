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

        public string BlazorValue
        {
            get
            {
                if (_propertyInfo == null)
                    return null;

                if (_obj == null)
                    return null;

                return _propertyInfo?.GetValue(_obj)?.ToString() ?? string.Empty;
            }
            set
            {
                if (_propertyInfo != null && _obj != null)
                {
                    if (_propertyInfo.PropertyType == typeof(DateTime) || _propertyInfo.PropertyType == typeof(DateTime?))
                    {
                        if (DateTime.TryParse(value, out var dt))
                        {
                            _propertyInfo.SetValue(_obj, dt);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(double) || _propertyInfo.PropertyType == typeof(double?))
                    {
                        if (double.TryParse(value, out var dt))
                        {
                            _propertyInfo.SetValue(_obj, dt);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(decimal) || _propertyInfo.PropertyType == typeof(decimal?))
                    {
                        if (decimal.TryParse(value, out var dt))
                        {
                            _propertyInfo.SetValue(_obj, dt);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(float) || _propertyInfo.PropertyType == typeof(float?))
                    {
                        if (float.TryParse(value, out var dt))
                        {
                            _propertyInfo.SetValue(_obj, dt);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(int) || _propertyInfo.PropertyType == typeof(int?))
                    {
                        if (int.TryParse(value, out var dt))
                        {
                            _propertyInfo.SetValue(_obj, dt);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(uint) || _propertyInfo.PropertyType == typeof(uint?))
                    {
                        if (uint.TryParse(value, out var dt))
                        {
                            _propertyInfo.SetValue(_obj, dt);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(ulong) || _propertyInfo.PropertyType == typeof(ulong?))
                    {
                        if (ulong.TryParse(value, out var dt))
                        {
                            _propertyInfo.SetValue(_obj, dt);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(bool) || _propertyInfo.PropertyType == typeof(bool?))
                    {
                        if (bool.TryParse(value, out var dt))
                        {
                            _propertyInfo.SetValue(_obj, dt);
                        }
                    }
                    else
                    {
                        _propertyInfo.SetValue(_obj, value.ToString());
                    }
                }
            }
        }

        public object RawValue
        {
            get
            {
                if (_propertyInfo == null)
                    return null;

                if (_obj == null)
                    return null;

                return _propertyInfo.GetValue(_obj);
            }
        }
        public object Value
        {
            get
            {
                if (_propertyInfo == null)
                    return null;

                if (_obj == null)
                    return null;

                var tmpValue = _propertyInfo.GetValue(_obj);
                if (IsDatetime)
                {
                    return ((DateTime?)tmpValue)?.ToString("yyyy-MM-dd");
                }
                else if (IsDecimal)
                {
                    return ((decimal?)tmpValue)?.ToString("0.00");
                }
                else
                {
                    return tmpValue;
                }
            }
        }

        #endregion
    }
}