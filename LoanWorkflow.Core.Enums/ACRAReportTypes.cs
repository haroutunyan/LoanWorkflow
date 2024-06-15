using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Core.Enums
{
    public enum ACRAReportTypes
    {
        [XmlEnum("01")]
        Full,

        [XmlEnum("02")]
        FullAndFayko,

        [XmlEnum("03")]
        Fayko,

        [XmlEnum("05")]
        AVH
    }
}
