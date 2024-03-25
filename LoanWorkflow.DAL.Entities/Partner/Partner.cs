using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Approvers;
using Microsoft.AspNetCore.Identity;

namespace LoanWorkflow.DAL.Entities.Users
{
    public class Partner : Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
