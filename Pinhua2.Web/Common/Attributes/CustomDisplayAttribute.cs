using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pinhua2.Web.Common.Attributes
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
        public int Order { get; set; } = 100;
        //public bool OnIndex { get; set; } = true;
        //public bool OnCreate { get; set; } = true;
        //public bool OnDetails { get; set; } = true;
        //public bool OnEdit { get; set; } = true;
        //public bool OnDelete { get; set; } = true;
        public PropertyInfo Property { get; set; }
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
                        OnIndexList.Add(new CustomDisplayModel
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).OnCreate)
                        OnCreateList.Add(new CustomDisplayModel
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).OnDetails)
                        OnDetailsList.Add(new CustomDisplayModel
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).OnEdit)
                        OnEditList.Add(new CustomDisplayModel
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });
                    if ((attrs[0] as CustomDisplayAttribute).OnDelete)
                        OnDeleteList.Add(new CustomDisplayModel
                        {
                            Order = (attrs[0] as CustomDisplayAttribute).Order,
                            Property = property
                        });

                }
                else
                {
                    OnIndexList.Add(new CustomDisplayModel { Property = property });
                    OnCreateList.Add(new CustomDisplayModel { Property = property });
                    OnDetailsList.Add(new CustomDisplayModel { Property = property });
                    OnEditList.Add(new CustomDisplayModel { Property = property });
                    //OnDeleteList.Add(new CustomDisplayModel { Property = property });
                }
            }
        }

    }
}