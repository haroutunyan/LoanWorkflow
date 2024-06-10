using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record SoleRequest1Model : SoleCommonRequestModel
    {
        public SoleRequest1Model() => Type = ACRARequestType.BankPersonOrgList;

        [XmlElement("Participient")]
        public SoleParticipientRequest1Model Participient { get; set; }
    }
}