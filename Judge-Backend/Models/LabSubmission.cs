using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judge_Backend.Models
{
    public class LabSubmission
    {
        public int ID { get; set; }
        public string source_code { get; set; } = default!;
        public string? Result { get; set; }
        public bool ExecutedCorrectly { get; set; }

        // Relationships
        public int UserID { get; set; }
        public User User { get; set; } = default(User)!;
        public int LabID { get; set; }
        public Lab Lab { get; set; } = default(Lab)!;
    }
}