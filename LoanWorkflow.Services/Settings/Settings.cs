using LoanWorkflow.Core.Options;
using LoanWorkflow.Services.Interfaces.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Settings
{
    public class Settings(
        IOptions<JwtSettings> jwt,
        IOptions<LoginProviderSettings> login) : ISettings
    {
        public JwtSettings JwtSettings => jwt.Value;
        public LoginProviderSettings LoginProviderSettings => login.Value;
    }
}
