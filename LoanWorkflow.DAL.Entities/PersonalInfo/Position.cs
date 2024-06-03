using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class Position
    {
        public int Id { get; set; }
        public string PositionName { get; set; }

        public ICollection<OtherIncome> OtherIncomes { get; set; }
    }
}
