using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Pledge
{
    public class MovableEstatePledge : PledgeBase
    {
        public MovableEstatePledge() => Type = PledgeType.MovableEstate;
        public Core.Enums.MovableEstateType MovableEstateType { get; set; }
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public string CarCertificateNumber { get; set; }
        public CarBodyType BodyType { get; set; }
        public string Color { get; set; }
        public int MakeYear { get; set; }
    }
}
