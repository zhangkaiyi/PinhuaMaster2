using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomDisplayAttribute : Attribute
    {
        public int Order { get; } = 100;
        public bool OnIndex { get; set; } = true;
        public bool OnCreate { get; set; } = true;
        public bool OnDetails { get; set; } = true;
        public bool OnEdit { get; set; } = true;
        public bool OnDelete { get; set; } = true;
        public CustomDisplayAttribute(int displayOrder = 100)
        {
            Order = displayOrder;
        }
    }

    public class CustomDisplayModel
    {
        private readonly object _obj;

        public CustomDisplayModel(object obj)
        {
            _obj = obj;
        }
        public int Order { get; set; } = 100;

        #region 注释掉的
        //public bool OnIndex { get; set; } = true;
        //public bool OnCreate { get; set; } = true;
        //public bool OnDetails { get; set; } = true;
        //public bool OnEdit { get; set; } = true;
        //public bool OnDelete { get; set; } = true;
        #endregion

        public PropertyInfo Property { get; set; }
        public string Name
        {
            get
            {
                if (Property == null)
                    return string.Empty;

                var attrs = Property.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
                }
                else
                {
                    return Property.Name;
                }
            }
        }
        public string RawName
        {
            get
            {
                return Property?.Name ?? string.Empty;
            }
        }

        public object Value
        {
            get
            {
                if (Property == null)
                    return null;
                return Property.GetValue(_obj);
            }
        }

        public bool IsRequired
        {
            get
            {
                if (Property == null)
                    return false;

                var attrs = Property.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), false);
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
        public bool IsDatetime
        {
            get
            {
                if (Property == null)
                    return false;
                else
                {
                    var propType = Property.PropertyType;
                    var dtType1 = typeof(DateTime);
                    var dtType2 = typeof(DateTime?);
                    return (propType == dtType1) || propType == dtType2;
                }
            }
        }
    }
    public class CustomDisplayProvider
    {
        public IList<CustomDisplayModel> OnIndexList { get; } = new List<CustomDisplayModel>();
        public IList<CustomDisplayModel> OnCreateList { get; } = new List<CustomDisplayModel>();
        public IList<CustomDisplayModel> OnDetailsList { get; } = new List<CustomDisplayModel>();
        public IList<CustomDisplayModel> OnEditList { get; } = new List<CustomDisplayModel>();
        public IList<CustomDisplayModel> OnDeleteList { get; } = new List<CustomDisplayModel>();
        public CustomDisplayProvider(object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                var attrs = property.GetCustomAttributes(typeof(CustomDisplayAttribute), false);
                if (attrs.Length > 0)
                {
                    if ((attrs[0] as CustomDisplayAttribute).OnIndex)
                        OnIndexList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).OnCreate)
                        OnCreateList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).OnDetails)
                        OnDetailsList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).OnEdit)
                        OnEditList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).OnDelete)
                        OnDeleteList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });

                }
                else
                {
                    OnIndexList.Add(new CustomDisplayModel(obj) { Property = property });
                    OnCreateList.Add(new CustomDisplayModel(obj) { Property = property });
                    OnDetailsList.Add(new CustomDisplayModel(obj) { Property = property });
                    OnEditList.Add(new CustomDisplayModel(obj) { Property = property });
                    //OnDeleteList.Add(new CustomDisplayModel { Property = property });
                }
            }
        }
    }
}