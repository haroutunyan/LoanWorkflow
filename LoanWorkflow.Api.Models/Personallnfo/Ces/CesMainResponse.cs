using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo.Ces
{
    public record CesMainResponse : MainPageResponse
    {
        public IEnumerable<CesMainDTO> CesData { get; set; }
    }

    public record CesMainDTO
    {
        
    }
}
