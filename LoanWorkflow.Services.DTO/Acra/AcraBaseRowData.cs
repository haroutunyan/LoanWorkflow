using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record AcraBaseRowData
    {
        [XmlElement(ElementName = "ReqID")]
        public string ReqID { get; set; }

        [XmlElement(ElementName = "SID")]
        public string SID { get; set; }

        [XmlElement(ElementName = "Error")]
        public string Error { get; set; }
    }
}
