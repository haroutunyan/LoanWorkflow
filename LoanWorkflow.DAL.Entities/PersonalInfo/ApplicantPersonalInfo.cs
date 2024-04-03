using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class ApplicantPersonalInfo : Entity
    {
        public long Id { get; set; }
        public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

        public Guid PersonalInfoId { get; set; }
        public PersonalInfoBase PersonalInfo { get; set; }
    }
}
