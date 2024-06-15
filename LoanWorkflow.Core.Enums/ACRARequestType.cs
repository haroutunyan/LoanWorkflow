using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Core.Enums
{
    public enum ACRARequestType
    {
        [XmlEnum("Bank_LogIn")]
        BankLogin,

        [XmlEnum("Bank_LogOut")]
        BankLogOut,

        [XmlEnum("Bank_PersonOrg_List")]
        BankPersonOrgList,

        [XmlEnum("Bank_Application_LOAN_PP")]
        BankApplicationLOANPP,

        [XmlEnum("Bank_Application_LOAN_JP")]
        BankApplicationLOANJP
    }
}
