using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Models;

namespace Task.Core.Validators
{
    public abstract class BaseValidator<T> :
        AbstractValidator<T>, IValidator<T>
    {

        public ValidateResult Valid(T model)
        {
            ValidateResult result = new ValidateResult();
            ValidationResult results = Validate(model);
            result.IsOk = results.IsValid;
            result.Errors = results.Errors.Select(x => x.ErrorMessage).ToArray();
            return result;
        }
    }
}
