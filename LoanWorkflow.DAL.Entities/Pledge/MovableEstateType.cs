using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.Pledge
{
    public class MovableEstateType : Entity
    {
        public Core.Enums.MovableEstateType Type { get; set; }
        public string Name { get; set; }
        public ICollection<MovableEstatePledge> Pledges { get; set; }
    }
}
