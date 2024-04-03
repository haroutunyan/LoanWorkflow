using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "ROWDATA")]
    [XmlType("ROWDATA")]
    public record AcraAuthResponseRowData : AcraBaseRowData
    {
        [XmlElement(ElementName = "Response")]
        public string Response { get; set; }
    }
}
