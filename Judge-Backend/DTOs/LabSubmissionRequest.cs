using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judge_Backend.DTOs
{
    public class LabSubmissionRequest
    {
        public int LabID { get; set; }
        public string SourceCode { get; set; } = string.Empty;
    }
}