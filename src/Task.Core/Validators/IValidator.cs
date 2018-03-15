using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core.Validators
{
    public interface IValidator<T>
    {
        //string[] Errors { get; set; }
        //bool IsValid(T model);
        ValidateResult Valid(T model);
    }
}
