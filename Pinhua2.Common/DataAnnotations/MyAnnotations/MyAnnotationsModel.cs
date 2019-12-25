using Pinhua2.Common.Attributes;
using Pinhua2.Common.MyAnnotations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TagHelpers;

namespace Pinhua2.Common.MyAnnotations
{
    public partial class MyAnnotationsModel
    {
        internal readonly object _obj;

        internal readonly PropertyInfo _propertyInfo;

        public PropertyInfo GetCurrentProperty()
        {
            return _propertyInfo;
        }

        public object GetCurrentObject()
        {
            return _obj;
        }

        public FormControlModel FormControl { get; set; }

        public FieldModel Field { get; set; }

        public MyAnnotationsModel(PropertyInfo propertyInfo, object obj)
        {
            _obj = obj;
            _propertyInfo = propertyInfo;

            FormControl = new FormControlModel(this);
            Field = new FieldModel(this);
        }

    }
}