namespace LoanWorkflow.DAL.Entities.Pledge
{
    public class MovableEstateType
    {
        public Core.Enums.MovableEstateType Type { get; set; }
        public string Name { get; set; }
        public ICollection<MovableEstatePledge> Pledges { get; set; }
    }
}
