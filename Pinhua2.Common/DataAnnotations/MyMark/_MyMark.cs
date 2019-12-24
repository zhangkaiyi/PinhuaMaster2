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
        private readonly object _obj;

        private readonly PropertyInfo _propertyInfo;

        public MyMarkModel(PropertyInfo propertyInfo, object obj)
        {
            _obj = obj;
            _propertyInfo = propertyInfo;

        }
        #region 各种属性
        public string ViewComponentName
        {
            get
            {
                if (_propertyInfo == null)
                    return string.Empty;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyViewComponentAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as MyViewComponentAttribute).Name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string Name
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
        public string RawName
        {
            get
            {
                return _propertyInfo?.Name ?? string.Empty;
            }
        }

        public bool IsRequired
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), false);
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

        public bool IsReadonly
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(ReadonlyAttribute), false);
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

        public bool IsHiddenIndex
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyHiddenIndexAttribute), false);
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

        public bool IsHiddenCreate
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyHiddenCreateAttribute), false);
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

        public bool IsHiddenDetails
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyHiddenDetailsAttribute), false);
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

        public bool IsHiddenEdit
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyHiddenEditAttribute), false);
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

        public bool IsHiddenDelete
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyHiddenDeleteAttribute), false);
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

        public bool IsHiddenRef
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyHiddenRefAttribute), false);
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

        public bool IsVueComputed
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueComputedAttribute), false);
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

        public bool IsVueVModel
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueVModelAttribute), false);
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

        public string VueVModelTargetPrefix
        {
            get
            {
                if (_propertyInfo == null)
                    return string.Empty;
                if (_obj == null)
                    return string.Empty;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueVModelAttribute), false);
                if (attrs?.Length > 0)
                {
                    return $"{(attrs[0] as MyVueVModelAttribute).TargetPrefix}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public bool IsVueVBind
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueVBindAttribute), false);
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

        public IList<MyVBindModel> VueVBindModel
        {
            get
            {
                var r = new List<MyVBindModel>();
                if (IsVueVBind)
                {
                    var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueVBindAttribute), false);
                    foreach (MyVueVBindAttribute attr in attrs)
                    {
                        if (string.IsNullOrEmpty(attr.Prop) && !string.IsNullOrEmpty(attr.Method))
                            r.Add(new MyVBindModel
                            {
                                Prop = attr.Prop,
                                Method = attr.Method,
                                Args = attr.Args
                            });
                    }
                }
                return r;
            }
        }

        public string VueVBindAttr
        {
            get
            {
                if (_propertyInfo == null)
                    return string.Empty;
                if (_obj == null)
                    return string.Empty;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueVBindAttribute), false);
                if (attrs?.Length > 0)
                {
                    return $"{(attrs[0] as MyVueVBindAttribute).Prop}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string VueVBindMethod
        {
            get
            {
                if (_propertyInfo == null)
                    return string.Empty;
                if (_obj == null)
                    return string.Empty;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueVBindAttribute), false);
                if (attrs?.Length > 0)
                {
                    return $"{(attrs[0] as MyVueVBindAttribute).Method}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public bool IsVueVOn
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueVOnAttribute), false);
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


        public string VueVOnEvent
        {
            get
            {
                if (_propertyInfo == null)
                    return string.Empty;
                if (_obj == null)
                    return string.Empty;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueVOnAttribute), false);
                if (attrs?.Length > 0)
                {
                    return $"{(attrs[0] as MyVueVOnAttribute).Event}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string VueVOnMethod
        {
            get
            {
                if (_propertyInfo == null)
                    return string.Empty;
                if (_obj == null)
                    return string.Empty;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyVueVOnAttribute), false);
                if (attrs?.Length > 0)
                {
                    return $"{(attrs[0] as MyVueVOnAttribute).Method}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public bool IsViewComponent
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyViewComponentAttribute), false);
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

        public bool IsSysColumn
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

        public bool IsDropdown
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyDropdownAttribute), false);
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

        public Priority Priority
        {
            get
            {
                if (_propertyInfo == null)
                    return Priority.Low;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyPriorityAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as MyPriorityAttribute).Priority;
                }
                else
                    return Priority.Low;
            }
        }

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

        public double? MinWidth
        {
            get
            {
                if (_propertyInfo == null)
                    return null;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyMinWidthAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as MyMinWidthAttribute).MinWidth;
                }
                else
                {
                    return null;
                }
            }
        }
        public bool Editable
        {
            get
            {
                if (_propertyInfo == null)
                    return false;

                var attrs = _propertyInfo.GetCustomAttributes(typeof(MyEditableAttribute), false);
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

    public class MyMark
    {
        private IList<MyMarkModel> ParseType(Type type)
        {
            var list = new List<MyMarkModel>();
            foreach (var p in type.GetProperties())
            {
                var cdm = new MyMarkModel(p, null);
                list.Add(cdm);
            }
            return list.OrderBy(p => p.Order).ToList();
        }

        private IList<MyMarkModel> ParseObject(object obj)
        {
            if (obj == null)
                return null;

            var list = new List<MyMarkModel>();
            foreach (var p in obj.GetType().GetProperties())
            {
                var cdm = new MyMarkModel(p, obj);
                list.Add(cdm);
            }
            return list.OrderBy(p => p.Order).ToList();
        }

        public IList<MyMarkModel> Models { get; set; }

        static public IList<MyMarkModel> Parse(object obj)
        {
            //return new CustomDisplayFactory(obj.GetType(), obj).Models;
            return new MyMark().ParseObject(obj);
        }

        static public IList<MyMarkModel> Parse(Type type)
        {
            //return new CustomDisplayFactory(type, null).Models;
            return new MyMark().ParseType(type);
        }
    }
}