﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core.Validators
{
    public class ValidateResult
    {
        public bool IsOk { get; set; }
        public string[] Errors{ get; set; }
    }
}
