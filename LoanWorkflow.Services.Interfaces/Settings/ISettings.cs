using LoanWorkflow.Core.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Interfaces.Settings
{
    public interface ISettings
    {
        JwtSettings JwtSettings { get; }
        LoginProviderSettings LoginProviderSettings { get; }
    }
}
