using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record class AcraRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string SocialCard { get; set; }
        public required string Passport { get; set; }
        public required string IdCard { get; set; }
        public required AvhRequestType RequestType { get; set; }
        public required UsageRange UsageRange { get; set; }
        public required RequestTarget RequestTarget { get; set; }
        public required ACRAReportTypes ACRAReportType { get; set; }
    }
}
