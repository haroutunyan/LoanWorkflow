using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.UserAccount
{
    public class RefreshTokenResponseModel
    {
        public string RefreshToken { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
