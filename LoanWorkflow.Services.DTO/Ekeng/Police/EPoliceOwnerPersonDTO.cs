using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record EPoliceOwnerPersonDTO : EPolicePersonBaseDTO
    {
        public EVehicleDTO EVehicle { get; set; }
    }
}
