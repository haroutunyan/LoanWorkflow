using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class TaxData : PersonalInfoBase
    {
        public TaxData() => PersonalInfoType = Core.Enums.PersonalInfoType.Tax;
        public ICollection<TaxPayerInfo> TaxPayerInfo { get; set; }
    }

    public class TaxPayerInfo
    {
        public string TaxPayerId { get; set; }
        public ICollection<PersonInfoPeriod> PersonInfoPeriods { get; set; }
    }

    public class PersonInfoPeriod
    {
        public DateTime Date { get; set; }
        public PersonInfo PersonInfo { get; set; }
    }

    public class PersonInfo
    {
        public decimal IncomeTax { get; set; }
        public decimal Socialpayments { get; set; }
        public decimal SocialPaymentsPaid { get; set; }
        public int WorkingHours { get; set; }
        public decimal SalaryEquivPayments { get; set; }
        public decimal CivilLowContractPayments { get; set; }
    }
}
