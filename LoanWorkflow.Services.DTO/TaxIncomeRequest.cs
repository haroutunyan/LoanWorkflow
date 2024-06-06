using LoanWorkflow.Services.DTO.Ekeng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO
{
    public record TaxIncomeRequest : RequestSsn
    {
        [XmlElement("startdate", IsNullable = true)]
        public required string StartDate { get; set; }

        [XmlElement("enddate", IsNullable = true)]
        public required string EndDate { get; set; }
    }
}
