﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FormUrlNameAttribute(string propertyName) : Attribute
    {
        public string PropertyName { get; private set; } = propertyName;
    }
}
