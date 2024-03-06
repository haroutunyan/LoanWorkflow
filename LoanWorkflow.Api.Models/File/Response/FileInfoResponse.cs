using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.File.Response
{
    public class FileInfoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DocTypeName { get; set; }
        public string Extension { get; set; }
        public DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}
