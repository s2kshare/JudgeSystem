using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judge_Backend.Models
{
    // Join table between Student and Paper
    public class Enrollment
    {
        public int StudentID { get; set; }
        public Student Student { get; set; } = default(Student)!;

        public int PaperID { get; set; }
        public Paper Paper { get; set; } = default(Paper)!;
    }
}