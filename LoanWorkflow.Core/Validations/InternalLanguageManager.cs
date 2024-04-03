using FluentValidation.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Validations
{
    public class InternalLanguageManager : ILanguageManager
    {
        public bool Enabled { get; set; }
        public CultureInfo Culture { get; set; }

        public string GetString(string key, CultureInfo culture = null)
        {
            return InternalLanguage.GetTranslation(key);
        }
    }
}
