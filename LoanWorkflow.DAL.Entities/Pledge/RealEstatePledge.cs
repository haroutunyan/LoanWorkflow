using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Pledge
{
    public class RealEstatePledge : PledgeBase
    {
        public RealEstatePledge() => Type = PledgeType.RealEstate;

    }
}
