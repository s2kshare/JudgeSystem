using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Judge_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Judge_Backend.Data
{
    public class JudgeDbContext : DbContext
    {
        public JudgeDbContext(DbContextOptions<JudgeDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<LabSubmission> LabSubmissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasDiscriminator<string>("UserType")
                .HasValue<Student>("Student")
                .HasValue<Teacher>("Teacher")
                .HasValue<Admin>("Admin");

            // Many-to-many relationship between Paper and Students (Enrolled)
            modelBuilder.Entity<Paper>()
                .HasMany(p => p.EnrolledStudents)
                .WithMany(s => s.EnrolledPapers)
                .UsingEntity<Enrollment>(
                    j => j.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentID).OnDelete(DeleteBehavior.NoAction),
                    j => j.HasOne(e => e.Paper).WithMany().HasForeignKey(e => e.PaperID).OnDelete(DeleteBehavior.NoAction)
                );


            // One-to-many relationship between Lab and LabSubmission
            modelBuilder.Entity<Lab>()
                .HasMany(l => l.LabSubmissions)
                .WithOne(ls => ls.Lab)
                .HasForeignKey(ls => ls.LabID);

            // One-to-many relationship between LabSubmission and User (Teacher or Student)
            modelBuilder.Entity<LabSubmission>()
                .HasOne(ls => ls.User)
                .WithMany()
                .HasForeignKey(ls => ls.UserID)
                .OnDelete(DeleteBehavior.NoAction);  // Prevent cascade deletes

            // One-to-many relationship between Paper and Teacher
            modelBuilder.Entity<Paper>()
                .HasOne(p => p.Teacher)
                .WithMany() // Teachers can have many papers
                .HasForeignKey(p => p.TeacherID);  // Explicitly map the foreign key to TeacherId
        }

    }
}