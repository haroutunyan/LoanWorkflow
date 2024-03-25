using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.Ces
{
    public record EInquest
    {
        [JsonProperty("inquestid")]
        public string InquestId { get; set; }

        [JsonProperty("inputdate")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? InquestDate { get; set; }

        [JsonProperty("claimsum")]
        public decimal ClaimSum { get; set; }

        [JsonProperty("aliment")]
        public decimal Aliment { get; set; }

        [JsonProperty("plaintiffname")]
        public string PlaintiffName { get; set; }

        [JsonProperty("inqueststate")]
        public int InquestState { get; set; }

        [JsonProperty("inquesttype")]
        public string InquestType { get; set; }

        [JsonProperty("bashxmankarg")]
        public string DistributionProcedure { get; set; }

        [JsonProperty("changedate")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? ChangeDate { get; set; }

        [JsonProperty("article")]
        public string Article { get; set; }

        [JsonProperty("courtid")]
        public string CourtId { get; set; }

        [JsonProperty("ordernumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("ordertext")]
        public string OrderText { get; set; }

        [JsonProperty("oldordertext")]
        public string OldOrderText { get; set; }

        [JsonProperty("orderdate")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? OrderDate { get; set; }

        [JsonProperty("inquestrem")]
        public decimal RemainingSum { get; set; }

        [JsonProperty("recoversum")]
        public decimal RecoverSum { get; set; }

        [JsonProperty("calcpersent")]
        public int CalcPersent { get; set; }

        [JsonProperty("debtorname")]
        public string DebtorName { get; set; }

        [JsonProperty("debtoraddress")]
        public string DebtorAddress { get; set; }
    }
}
