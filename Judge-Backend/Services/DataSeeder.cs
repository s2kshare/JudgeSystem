using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Judge_Backend.Data;
using Judge_Backend.Models;

namespace Judge_Backend.Services
{
    public static class DataSeeder
    {
        public static void SeedUsers(JudgeDbContext context)
        {
            if (!context.Users.Any())
            {
                var admin = new Admin
                {
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
                    Role = "Admin"
                };

                var teacher = new Teacher
                {
                    Username = "teacher",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("teacher"),
                    Role = "Teacher"
                };

                var student = new Student
                {
                    Username = "student",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("student"),
                    Role = "Student"
                };

                context.AddRange(admin, teacher, student);
                context.SaveChanges();
            }
        }
    }
}