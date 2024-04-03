using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.Pledge
{
    public class RealEstateType :Entity
    {
        public Core.Enums.RealEstateType Type { get; set; }
        public string Name { get; set; }
        public ICollection<RealEstatePledge> Pledges { get; set; }
    }
}
