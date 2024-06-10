using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.ECivil
{
    public record CivilPersonResidentDTO
    {
        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("community")]
        public string Community { get; set; }

        [JsonProperty("residence")]
        public string Residence { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("house_type")]
        public string HouseType { get; set; }

        [JsonProperty("house")]
        public string House { get; set; }

        [JsonProperty("apartment")]
        public string Apartment { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        //[JsonProperty("start_date")]
        //[JsonConverter(typeof(DateFormatConverter), ["dd-MM-yyyy"])]
        //public DateTime? StartDate { get; set; }

        //[JsonProperty("end_date")]
        //[JsonConverter(typeof(DateFormatConverter), ["dd-MM-yyyy"])]
        //public DateTime? EndDate { get; set; }
    }
}
