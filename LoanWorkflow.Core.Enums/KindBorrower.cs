using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Core.Enums
{
    public enum KindBorrower
    {
        [XmlEnum("1")]
        Individual = 1,

        [XmlEnum("2")]
        Entity
    };
}
