using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Pledge
{
    public class PledgeFile : Entity
    {
        public long Id { get; set; }

        public Guid PledgId { get; set; }
        public PledgeBase Pledge { get; set; }

        public Guid FileId { get; set; }
        public File.File File { get; set; }
    }
}
