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
    public class CustomerValidator
        : BaseValidator<Customer>, ICustomerValidator
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("müşteri adı boş olamaz");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("müşteri soyadı boş olamaz");
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(15)
                .MinimumLength(3)
                .WithMessage("müşteri telefon numarası boş olamaz");
        }

    }
}
