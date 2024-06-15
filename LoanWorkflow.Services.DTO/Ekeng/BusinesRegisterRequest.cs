using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng
{
    public class BusinesRegisterRequest
    {
        [JsonProperty("jsonrpc")]
        public required string JsonRPC { get; set; }

        [JsonProperty("method")]
        public required string Method { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("params")]
        public required RequestSsn Params { get; set; }
    }
}
