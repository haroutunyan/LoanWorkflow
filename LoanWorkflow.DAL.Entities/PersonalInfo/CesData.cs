using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class CesData : PersonalInfoBase
    {
        public CesData() => PersonalInfoType = Core.Enums.PersonalInfoType.Ces;
        public ICollection<EInquest> Inquests { get; set; }
    }

    public class EInquest
    {
        public string InquestId { get; set; }
        public DateTime? InquestDate { get; set; }
        public decimal? ClaimSum { get; set; }
        public decimal? Aliment { get; set; }
        public string PlaintiffName { get; set; }
        public int? InquestState { get; set; }
        public string InquestType { get; set; }
        public string DistributionProcedure { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string Article { get; set; }
        public string CourtId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderText { get; set; }
        public string OldOrderText { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? RemainingSum { get; set; }
        public decimal? RecoverSum { get; set; }
        public int? CalcPersent { get; set; }
        public string DebtorName { get; set; }
        public string DebtorAddress { get; set; }
    }
}
