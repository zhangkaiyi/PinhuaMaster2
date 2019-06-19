using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyMinWidthAttribute : Attribute
    {
        public double MinWidth { get; }
        public MyMinWidthAttribute(double minWidth)
        {
            MinWidth = minWidth;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CustomDisplayAttribute : Attribute
    {
        public double Order { get; } = 100;
        public bool IsRendered { get; set; } = true;
        public bool ForIndex { get; set; } = true;
        public bool ForCreate { get; set; } = false;
        public bool ForRead { get; set; } = true;
        public bool ForUpdate { get; set; } = false;
        public bool ForDelete { get; set; } = true;
        public CustomDisplayAttribute(double displayOrder = 100)
        {
            Order = displayOrder;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ReadonlyAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotRenderedAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MyEditableAttribute : Attribute
    {
    }

    public class CustomDisplayModel
    {
        private readonly object _obj;

        public CustomDisplayModel(object obj)
        {
            _obj = obj;

        }
        public double Order { get; set; } = 100;

        public bool ForCreate { get; set; }
        public bool ForRead { get; set; }
        public bool ForUpdate { get; set; }
        public bool ForDelete { get; set; }
        public bool ForIndex { get; set; }

        public PropertyInfo PropertyInfo { get; set; }
        public string Name
        {
            get
            {
                if (PropertyInfo == null)
                    return string.Empty;

                var attrs = PropertyInfo.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
                }
                else
                {
                    return PropertyInfo.Name;
                }
            }
        }
        public string RawName
        {
            get
            {
                return PropertyInfo?.Name ?? string.Empty;
            }
        }

        public object RawValue
        {
            get
            {
                if (PropertyInfo == null)
                    return null;
                return PropertyInfo.GetValue(_obj);
            }
        }
        public object Value
        {
            get
            {
                if (PropertyInfo == null)
                    return null;

                var tmpValue = PropertyInfo.GetValue(_obj);
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

        public bool IsRequired
        {
            get
            {
                if (PropertyInfo == null)
                    return false;

                var attrs = PropertyInfo.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), false);
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
                if (PropertyInfo == null)
                    return false;

                var attrs = PropertyInfo.GetCustomAttributes(typeof(ReadonlyAttribute), false);
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

        public bool IsPrimary { get; set; }

        public bool IsSecondary { get; set; }

        public bool IsDatetime
        {
            get
            {
                if (PropertyInfo == null)
                    return false;
                else
                {
                    var propType = PropertyInfo.PropertyType;
                    var dtType1 = typeof(DateTime);
                    var dtType2 = typeof(DateTime?);
                    return (propType == dtType1) || propType == dtType2;
                }
            }
        }

        public double? MinWidth { get; set; }
        public bool Editable { get; set; }

        public bool IsDecimal
        {
            get
            {
                if (PropertyInfo == null)
                    return false;
                else
                {
                    var propType = PropertyInfo.PropertyType;
                    var dtType1 = typeof(decimal);
                    var dtType2 = typeof(decimal?);
                    return (propType == dtType1) || propType == dtType2;
                }
            }
        }
    }

    public class CustomDisplayFactory
    {
        private CustomDisplayFactory() { }

        private CustomDisplayFactory(Type type, object obj)
        {
            var list = new List<CustomDisplayModel>();
            foreach (var p in type.GetProperties())
            {
                var attrs = p.GetCustomAttributes(typeof(CustomDisplayAttribute), false);
                var cdm = new CustomDisplayModel(obj);
                if (attrs.Length > 0)
                {
                    var cda = attrs[0] as CustomDisplayAttribute;

                    cdm.ForIndex = cda.ForIndex;
                    cdm.ForCreate = cda.ForCreate;
                    cdm.ForRead = cda.ForRead;
                    cdm.ForUpdate = cda.ForUpdate;
                    cdm.ForDelete = cda.ForDelete;
                    cdm.Order = cda.Order;
                    cdm.PropertyInfo = p;
                }
                else
                {
                    cdm.ForIndex = true;
                    cdm.ForCreate = true;
                    cdm.ForRead = true;
                    cdm.ForUpdate = true;
                    cdm.ForDelete = true;
                    cdm.PropertyInfo = p;
                }
                attrs = p.GetCustomAttributes(typeof(MyMinWidthAttribute), false);
                if (attrs.Length > 0)
                {
                    var cda = attrs[0] as MyMinWidthAttribute;
                    cdm.MinWidth = cda.MinWidth;
                }
                attrs = p.GetCustomAttributes(typeof(MyEditableAttribute), false);
                if (attrs.Length > 0)
                {
                    var cda = attrs[0] as MyEditableAttribute;
                    cdm.Editable = true;
                }
                else
                {
                    cdm.Editable = false;
                }
                attrs = p.GetCustomAttributes(typeof(MyPrimaryAttribute), false);
                if (attrs.Length > 0)
                {
                    var cda = attrs[0] as MyPrimaryAttribute;
                    cdm.IsPrimary = true;
                }
                else
                {
                    cdm.IsPrimary = false;
                }
                attrs = p.GetCustomAttributes(typeof(MySecondaryAttribute), false);
                if (attrs.Length > 0)
                {
                    var cda = attrs[0] as MySecondaryAttribute;
                    cdm.IsSecondary = true;
                }
                else
                {
                    cdm.IsSecondary = false;
                }
                list.Add(cdm);
            }
            Models = list.OrderBy(p => p.Order).ToList();
        }

        public IList<CustomDisplayModel> Models { get; set; }

        static public CustomDisplayFactory Create(Type type, object obj)
        {
            return new CustomDisplayFactory(type, obj);
        }

        static public IList<CustomDisplayModel> CustomDisplayModels(object obj)
        {
            return new CustomDisplayFactory(obj.GetType(), obj).Models;
        }

        static public IList<CustomDisplayModel> CustomDisplayModels(Type type)
        {
            return new CustomDisplayFactory(type, null).Models;
        }
    }


    public class CustomDisplayFactory<T>
    {
        private CustomDisplayFactory() { }

        private CustomDisplayFactory(T obj)
        {
            var list = new List<CustomDisplayModel>();
            foreach (var p in typeof(T).GetProperties())
            {
                var attrs = p.GetCustomAttributes(typeof(CustomDisplayAttribute), false);
                var cdm = new CustomDisplayModel(obj);
                if (attrs.Length > 0)
                {
                    var cda = attrs[0] as CustomDisplayAttribute;

                    cdm.ForIndex = cda.ForIndex;
                    cdm.ForCreate = cda.ForCreate;
                    cdm.ForRead = cda.ForDelete;
                    cdm.ForUpdate = cda.ForUpdate;
                    cdm.ForDelete = cda.ForDelete;
                    cdm.Order = cda.Order;
                    cdm.PropertyInfo = p;
                }
                else
                {
                    cdm.ForIndex = true;
                    cdm.ForCreate = true;
                    cdm.ForRead = true;
                    cdm.ForUpdate = true;
                    cdm.ForDelete = true;
                    cdm.PropertyInfo = p;
                }
                attrs = p.GetCustomAttributes(typeof(MyMinWidthAttribute), false);
                if (attrs.Length > 0)
                {
                    var cda = attrs[0] as MyMinWidthAttribute;
                    cdm.MinWidth = cda.MinWidth;
                }
                attrs = p.GetCustomAttributes(typeof(MyEditableAttribute), false);
                if (attrs.Length > 0)
                {
                    var cda = attrs[0] as MyEditableAttribute;
                    cdm.Editable = true;
                }
                else
                {
                    cdm.Editable = false;
                }
                list.Add(cdm);
            }
            Models = list.OrderBy(p => p.Order).ToList();
        }

        public IList<CustomDisplayModel> Models { get; set; }

        static public CustomDisplayFactory<T> Create(T obj)
        {
            return new CustomDisplayFactory<T>(obj);
        }

        static public IList<CustomDisplayModel> CustomDisplayModels(T obj)
        {
            return new CustomDisplayFactory<T>(obj).Models;
        }
    }
}