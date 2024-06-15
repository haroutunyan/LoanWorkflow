using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Core.Enums
{
    public enum RequestTarget
    {
        [XmlEnum("1")]
        NewLoanApp = 1,

        [XmlEnum("2")]
        NewLoanAppTest = 2,

        [XmlEnum("3")]
        Guarantor = 3,

        [XmlEnum("4")]
        Affiliate = 4
    };
}
