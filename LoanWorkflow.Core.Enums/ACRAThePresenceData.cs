using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Core.Enums
{
    public enum ACRAThePresenceData
    {
        [XmlEnum("0")]
        PersonDataMissing,

        [XmlEnum("1")]
        CreditReportAvailable,

        [XmlEnum("2")]
        CreditReportBlocked
    }
}
