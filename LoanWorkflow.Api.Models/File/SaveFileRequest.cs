﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.File
{
    public class SaveFileRequest
    {
        public IFormFile File { get; set; }
    }
}
