using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judge_Backend.Models
{
    public class Lab
    {
        public int ID { get; set; }
        public int LabNumber { get; set; }
        public string LabName { get; set; } = default!;

        // Judge Execution I/O
        public string LabInput { get; set; } = default!;
        public string LabOutput { get; set; } = default!;

        // Judge Example Execution I/O
        public string ExampleInput { get; set; } = default!;
        public string ExampleOutput { get; set; } = default!;

        // Relationships
        public int PaperID { get; set; }
        public Paper Paper { get; set; } = default!;
        public List<LabSubmission> LabSubmissions { get; set; } = new List<LabSubmission>();
    }
}