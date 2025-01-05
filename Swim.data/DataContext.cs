using Microsoft.EntityFrameworkCore;
using Swim.core.Entities;

namespace Swim.data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Course> courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=my_db");
        }

        //public DataContext()
        //{
        //     students = new List<Student>() { new Student() { Id = 1,
        //     FirstName = "David",
        //     LastName = "Cohen",
        //     Email = "david.cohen@example.com",
        //     Phone = "050-1234567",
        //     Age = 20,
        //     Address = "123 Main St, Tel Aviv",
        //     SchoolName = "Tel Aviv University",
        //     HealthInsurance = 12345,
        //     IsPaid = true,
        //     CourseId = 101} };

        //    teachers = new List<Teacher>() {  new Teacher() {  Id = 1,
        //     FirstName = "Dina",
        //     LastName = "Cohen",
        //     Email = "Dina.cohen@example.com",
        //     Phone = "050-6666666",
        //     Age = 20,
        //     Address = "Hoshe 14 bb",
        //     YearsOfSeniority=22,
        //    } };
        //    courses = new List<Course>() { new Course() {
        //    Id = 1,
        //    CurrentAmount = 5,
        //    MaxAmount = 20,
        //    DayOnWeek = "Monday",
        //    DateStart = new DateTime(2024, 1, 15),
        //    DateEnd = new DateTime(2024, 6, 15),
        //    AmountOfLessons =30,
        //    Type = "chaze",
        //    Price = 1000
        //    } };
    }
}

