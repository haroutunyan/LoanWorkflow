﻿using LoanWorkflow.DAL.Entities.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.User
{
    public class UserToken : IdentityUserToken<long>, IEntity
    {
        public long CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
