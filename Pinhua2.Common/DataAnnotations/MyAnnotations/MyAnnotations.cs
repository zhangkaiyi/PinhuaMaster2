using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TagHelpers;

namespace Pinhua2.Common.DataAnnotations
{
    public class MyAnnotations
    {
        private IList<MyAnnotationsModel> ParseType(Type type)
        {
            var list = new List<MyAnnotationsModel>();
            foreach (var p in type.GetProperties())
            {
                var cdm = new MyAnnotationsModel(p, null);
                list.Add(cdm);
            }
            return list.OrderBy(p => p.Field.Order).ToList();
        }

        private IList<MyAnnotationsModel> ParseObject(object obj)
        {
            if (obj == null)
                return null;

            var list = new List<MyAnnotationsModel>();
            foreach (var p in obj.GetType().GetProperties())
            {
                var cdm = new MyAnnotationsModel(p, obj);
                list.Add(cdm);
            }
            return list.OrderBy(p => p.Field.Order).ToList();
        }

        public IList<MyAnnotationsModel> Models { get; set; }

        static public IList<MyAnnotationsModel> Parse(object obj)
        {
            return new MyAnnotations().ParseObject(obj);
        }

        static public IList<MyAnnotationsModel> Parse(Type type)
        {
            return new MyAnnotations().ParseType(type);
        }
    }
}