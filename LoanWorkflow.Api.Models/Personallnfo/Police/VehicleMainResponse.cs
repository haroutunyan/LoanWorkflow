using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo.Police
{
    public record VehicleMainResponse : MainPageResponse
    {
        public IEnumerable<VehicleMainDTO> Vehicles { get; set; }
    }

    public record VehicleMainDTO
    {
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public string Date { get; set; }
        public bool HasInsurance { get; set; }
    }
}
