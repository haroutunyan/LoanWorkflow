using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Options
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public int TokenExpiration { get; set; }
        public string ValidateIssuer { get; set; }
        public string ValidateAudience { get; set; }
        public string ValidateIssuerSigningKey { get; set; }
    }
}
