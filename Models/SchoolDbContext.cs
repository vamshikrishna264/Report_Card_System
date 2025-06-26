using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Report_Card_System.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options):base(options) { }



        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ExamSubject> ExamSubjects { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>().HasData(
         new Class { Id = 1, Name = "10th Grade", Section = "A", AcademicYear = "2024-2025" }
     );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "John Doe", ClassId = 1 },
                new Student { Id = 2, Name = "Jane Smith", ClassId = 1 }
            );

            // Seed Exams
            modelBuilder.Entity<Exam>().HasData(
                new Exam { Id = 1, Name = "Mid Term" },
                new Exam { Id = 2, Name = "Final Exam" }
            );

            // Seed Subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Math" },
                new Subject { Id = 2, Name = "Science" }
            );

            // Seed ExamSubjects
            modelBuilder.Entity<ExamSubject>().HasData(
                new ExamSubject { Id = 1, ExamId = 1, SubjectId = 1, MaxMarks = 50 },
                new ExamSubject { Id = 2, ExamId = 1, SubjectId = 2, MaxMarks = 50 },
                new ExamSubject { Id = 3, ExamId = 2, SubjectId = 1, MaxMarks = 100 },
                new ExamSubject { Id = 4, ExamId = 2, SubjectId = 2, MaxMarks = 100 }
            );

            // Seed Marks
            modelBuilder.Entity<Mark>().HasData(
                new Mark { Id = 1, StudentId = 1, ExamSubjectId = 1, MarksObtained = 45 }, // John - MidTerm - Math
                new Mark { Id = 2, StudentId = 1, ExamSubjectId = 2, MarksObtained = 40 }, // John - MidTerm - Science
                new Mark { Id = 3, StudentId = 2, ExamSubjectId = 1, MarksObtained = 48 }, // Jane - MidTerm - Math
                new Mark { Id = 4, StudentId = 2, ExamSubjectId = 2, MarksObtained = 42 }, // Jane - MidTerm - Science
                new Mark { Id = 5, StudentId = 1, ExamSubjectId = 3, MarksObtained = 88 }, // John - Final - Math
                new Mark { Id = 6, StudentId = 1, ExamSubjectId = 4, MarksObtained = 90 }, // John - Final - Science
                new Mark { Id = 7, StudentId = 2, ExamSubjectId = 3, MarksObtained = 92 }, // Jane - Final - Math
                new Mark { Id = 8, StudentId = 2, ExamSubjectId = 4, MarksObtained = 91 }  // Jane - Final - Science
            );
        }
    }
}
