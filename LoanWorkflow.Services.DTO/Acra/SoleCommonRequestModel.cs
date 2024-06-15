using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record SoleCommonRequestModel : SoleRequestModel
    {
        [XmlElement("AppNumber")]
        public string AppNumber { get; set; }

        [XmlElement("DateTime")]
        public string ApplicationDate { get; set; }

        [XmlElement("SID")]
        public string SessionId { get; set; }

        [XmlElement("ReportType")]
        public ACRAReportTypes ReportType { get; set; }
    }
}
