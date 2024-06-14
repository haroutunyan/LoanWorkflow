using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "ROWDATA")]
    public record SoleRequest1Response : SoleResponse
    {
        [XmlElement("AppNumber")]
        public string AppNumber { get; set; }

        [XmlElement("DateTime")]
        public string ApplicationDate { get; set; }

        [XmlElement("PARTICIPIENT")]
        public SoleResponse1Participient Participient { get; set; }
    }
}
