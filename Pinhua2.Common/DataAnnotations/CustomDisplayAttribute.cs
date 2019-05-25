﻿using System;
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
        public bool ForIndex { get; set; } = true;
        public bool ForCreate { get; set; } = false;
        public bool ForRead { get; set; } = true;
        public bool ForUpdate { get; set; } = false;
        public bool ForDelete { get; set; } = true;
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

        public object Value
        {
            get
            {
                if (PropertyInfo == null)
                    return null;
                return PropertyInfo.GetValue(_obj);
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
                    if ((attrs[0] as CustomDisplayAttribute).ForIndex)
                        OnIndexList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).ForCreate)
                        OnCreateList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).ForRead)
                        OnDetailsList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).ForUpdate)
                        OnEditList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).ForDelete)
                        OnDeleteList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });

                }
                else
                {
                    OnIndexList.Add(new CustomDisplayModel(obj) { PropertyInfo = property });
                    OnCreateList.Add(new CustomDisplayModel(obj) { PropertyInfo = property });
                    OnDetailsList.Add(new CustomDisplayModel(obj) { PropertyInfo = property });
                    OnEditList.Add(new CustomDisplayModel(obj) { PropertyInfo = property });
                    //OnDeleteList.Add(new CustomDisplayModel { Property = property });
                }
            }


        }
        public CustomDisplayProvider(Type type, object obj = null)
        {
            foreach (var property in type.GetProperties())
            {
                var attrs = property.GetCustomAttributes(typeof(CustomDisplayAttribute), false);
                if (attrs.Length > 0)
                {
                    if ((attrs[0] as CustomDisplayAttribute).ForIndex)
                        OnIndexList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).ForCreate)
                        OnCreateList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).ForRead)
                        OnDetailsList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).ForUpdate)
                        OnEditList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).ForDelete)
                        OnDeleteList.Add(new CustomDisplayModel(obj)
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            PropertyInfo = property
                        });

                }
                else
                {
                    OnIndexList.Add(new CustomDisplayModel(obj) { PropertyInfo = property });
                    OnCreateList.Add(new CustomDisplayModel(obj) { PropertyInfo = property });
                    OnDetailsList.Add(new CustomDisplayModel(obj) { PropertyInfo = property });
                    OnEditList.Add(new CustomDisplayModel(obj) { PropertyInfo = property });
                    //OnDeleteList.Add(new CustomDisplayModel { Property = property });
                }
            }


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
                if (attrs.Length > 0)
                {
                    var cda = attrs[0] as CustomDisplayAttribute;
                    var cdm = new CustomDisplayModel(obj)
                    {
                        ForIndex = cda.ForIndex,
                        ForCreate = cda.ForCreate,
                        ForRead = cda.ForDelete,
                        ForUpdate = cda.ForUpdate,
                        ForDelete = cda.ForDelete,
                        Order = cda.Order,
                        PropertyInfo = p
                    };
                    list.Add(cdm);
                }
                else
                {
                    var cdm = new CustomDisplayModel(obj)
                    {
                        ForIndex = true,
                        ForCreate = true,
                        ForRead = true,
                        ForUpdate = true,
                        ForDelete = true,
                        PropertyInfo = p
                    };
                    list.Add(cdm);

                }
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