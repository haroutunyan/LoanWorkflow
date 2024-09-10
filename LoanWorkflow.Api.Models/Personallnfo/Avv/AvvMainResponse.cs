using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo.Avv
{
    public record AvvMainResponse
    {
        public IEnumerable<DocumentMainResponse> Documents { get; set; }
        public IEnumerable<AddressMainResponse> Addresses { get; set; }
    }

    public record DocumentMainResponse
    {
        public string PhotoPath { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public DateOnly IssuedDate { get; set; }
        public DateOnly ValidityDate { get; set; }
        public string IssuedBy { get; set; }
        public string Ssn { get; set; }
        public string FullName { get; set; }
        public string EnglishFullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<string> Citizenships { get; set; }
    }

    public record AddressMainResponse
    {
        public string Address { get; set; }
    }
}
