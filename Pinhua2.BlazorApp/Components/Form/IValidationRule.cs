using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klazor
{
    public interface IValidationRule
    {
        string ErrorMessage { get; set; }
        bool Validate(object value);
    }
}
