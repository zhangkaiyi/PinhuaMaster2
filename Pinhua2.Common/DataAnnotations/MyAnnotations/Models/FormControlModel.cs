using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TagHelpers;

namespace Pinhua2.Common.MyAnnotations.Models
{
    public partial class FormControlModel
    {
        protected MyAnnotationsModel _model;

        public FormControlModel(MyAnnotationsModel model)
        {
            _model = model;
        }
        public string Placeholder
        {
            get
            {
                if (_model._propertyInfo == null)
                    return string.Empty;

                var attrs = _model._propertyInfo.GetCustomAttributes(typeof(MyFormControlAttribute), false);
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
        public bool Visible
        {
            get
            {
                if (_model._propertyInfo == null)
                    return true;

                var attrs = _model._propertyInfo.GetCustomAttributes(typeof(MyFormControlAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as MyFormControlAttribute).Visible;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool Hidden
        {
            get
            {
                if (_model._propertyInfo == null)
                    return false;

                var attrs = _model._propertyInfo.GetCustomAttributes(typeof(MyFormControlAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as MyFormControlAttribute).Hidden;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Readonly
        {
            get
            {
                if (_model._propertyInfo == null)
                    return false;

                var attrs = _model._propertyInfo.GetCustomAttributes(typeof(MyFormControlAttribute), false);
                if (attrs?.Length > 0)
                {
                    return (attrs[0] as MyFormControlAttribute).Readonly;
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
                if (_model._propertyInfo == null)
                    return false;

                var attrs = _model._propertyInfo.GetCustomAttributes(typeof(MyDropdownAttribute), false);
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

        public bool IsFormControl
        {
            get
            {
                if (_model._propertyInfo == null)
                    return false;

                var attrs = _model._propertyInfo.GetCustomAttributes(typeof(MyFormControlAttribute), false);
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

    }
}