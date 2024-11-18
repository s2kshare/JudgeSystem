using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judge_Backend.Models
{
    public abstract class User
    {
        public int ID { get; set; }
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = default!;

        // Relationships
        public List<Paper> EnrolledPapers { get; set; } = new List<Paper>();
    }

    public class Admin : User { }
    public class Teacher : User { }
    public class Student : User { }
}