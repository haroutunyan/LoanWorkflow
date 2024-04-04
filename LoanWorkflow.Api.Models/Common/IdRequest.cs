using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Common
{
    public class IdRequest<T> where T : struct
    {
        public T Id { get; set; }
    }
}
