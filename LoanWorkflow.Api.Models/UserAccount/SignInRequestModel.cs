using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.UserAccount
{
    public class SignInRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
