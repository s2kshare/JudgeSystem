using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Judge_Backend.Models
{
    public class Paper
    {
        public int ID { get; set; }
        public string Name { get; set; } = default!;

        // Relationships
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
        public List<Lab> Labs { get; set; } = new List<Lab>();

        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; } = default(Teacher)!;
    }
}