using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Tools.CustomValidationAttribute
{
    public class GreaterOrEqualThanAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;

        public GreaterOrEqualThanAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Type t = validationContext.ObjectInstance.GetType();
            IComparable? max = value as IComparable;
            IComparable? min = t.GetProperty(_otherProperty)?.GetValue(validationContext.ObjectInstance) as IComparable;
            if (min is null || max is null)
            {
                return null;
            }
            return min.CompareTo(max) <= 0 ? null : new ValidationResult($"The value must be greater or equal than {min}");
        }
    }
}
