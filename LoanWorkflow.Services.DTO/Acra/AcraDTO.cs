using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Acra
{
    public class AcraDTO
    {
        public Guid? ResultId { get; set; }

        public AcraResult Result { get; set; }
    }
}
