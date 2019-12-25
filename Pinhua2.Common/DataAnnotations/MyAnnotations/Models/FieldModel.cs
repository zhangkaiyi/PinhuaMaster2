using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TagHelpers;

namespace Pinhua2.Common.MyAnnotations.Models
{
    public partial class FieldModel
    {
        protected MyAnnotationsModel _model;
        protected PropertyInfo _propertyInfo;
        protected object _obj;

        public FieldModel(MyAnnotationsModel model)
        {
            _model = model;
            _propertyInfo = model._propertyInfo;
            _obj = model._obj;
        }

        public double Order
        {
            get
            {
                if (_propertyInfo == null)
                    return 100;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyOrderAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as MyOrderAttribute).Order;
                }
                else
                {
                    return 100;
                }
            }
        }

        public bool IsSystemField
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MySysColumnAttribute), false);
                if (attrs?.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsHidden
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyHiddenAttribute), false);
                if (attrs?.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string ProcessedName
        {
            get
            {
                if (_propertyInfo == null)
                    return string.Empty;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
                }
                else
                {
                    return _propertyInfo.Name;
                }
            }
        }

        public string Name
        {
            get
            {
                return _propertyInfo?.Name ?? string.Empty;
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

                return _propertyInfo.GetValue(_obj);
            }
            set
            {
                if (_propertyInfo != null && _obj != null && value != null)
                {
                    var stringValue = value.ToString();
                    if (_propertyInfo.PropertyType == typeof(DateTime) || _propertyInfo.PropertyType == typeof(DateTime?))
                    {
                        if (DateTime.TryParse(stringValue, out var parsed))
                            _propertyInfo.SetValue(_obj, parsed);
                        else
                            _propertyInfo.SetValue(_obj, default);
                    }
                    else if (_propertyInfo.PropertyType == typeof(double) || _propertyInfo.PropertyType == typeof(double?))
                    {
                        if (double.TryParse(stringValue, out var parsed))
                        {
                            _propertyInfo.SetValue(_obj, parsed);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(decimal) || _propertyInfo.PropertyType == typeof(decimal?))
                    {
                        if (decimal.TryParse(stringValue, out var parsed))
                        {
                            _propertyInfo.SetValue(_obj, parsed);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(float) || _propertyInfo.PropertyType == typeof(float?))
                    {
                        if (float.TryParse(stringValue, out var parsed))
                        {
                            _propertyInfo.SetValue(_obj, parsed);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(int) || _propertyInfo.PropertyType == typeof(int?))
                    {
                        if (int.TryParse(stringValue, out var parsed))
                        {
                            _propertyInfo.SetValue(_obj, parsed);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(uint) || _propertyInfo.PropertyType == typeof(uint?))
                    {
                        if (uint.TryParse(stringValue, out var parsed))
                        {
                            _propertyInfo.SetValue(_obj, parsed);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(ulong) || _propertyInfo.PropertyType == typeof(ulong?))
                    {
                        if (ulong.TryParse(stringValue, out var parsed))
                        {
                            _propertyInfo.SetValue(_obj, parsed);
                        }
                    }
                    else if (_propertyInfo.PropertyType == typeof(bool) || _propertyInfo.PropertyType == typeof(bool?))
                    {
                        if (bool.TryParse(stringValue, out var parsed))
                        {
                            _propertyInfo.SetValue(_obj, parsed);
                        }
                    }
                    else
                    {
                        _propertyInfo.SetValue(_obj, stringValue);
                    }
                }
            }

        }
        public string ValueString
        {
            get
            {
                return Value?.ToString();
            }
            set
            {
                Value = value;
            }
        }
        public object ProcessedValue
        {
            get
            {
                if (_propertyInfo == null)
                    return null;

                if (_obj == null)
                    return null;

                var tmpValue = _propertyInfo.GetValue(_obj);
                if (_model.IsDatetime)
                {
                    return ((DateTime?)tmpValue)?.ToString("yyyy-MM-dd");
                }
                else if (_model.IsDecimal)
                {
                    return ((decimal?)tmpValue)?.ToString("0.00");
                }
                else
                {
                    return tmpValue;
                }
            }
        }
    }
}