using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Pledge
{
    public class RealEstateType
    {
        public Core.Enums.RealEstateType Type { get; set; }
        public string Name { get; set; }
        public ICollection<RealEstatePledge> Pledges { get; set; }
    }
}
