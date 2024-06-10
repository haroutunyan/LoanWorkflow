using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record SoleRequest2Model : SoleCommonRequestModel
    {
        public SoleRequest2Model() => Type = ACRARequestType.BankApplicationLOANPP;

        [XmlElement("Participient")]
        public SoleParticipientRequest2Model Participient { get; set; }
    }
}
