using Microsoft.EntityFrameworkCore;
using Swim.core.Entities;

namespace Swim.data
{
    public class FakeContext 
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Course> courses { get; set; }

        //public FakeContext()
        //{
        //    students = new List<Student>() { new Student()
        //    { Id = 1,
        //     FirstName = "aa",
        //     LastName = "aa",
        //     Email = "aa.cohen@example.com",
        //     Phone = "050-1234567",
        //     Age = 20,
        //     Address = "aa Main St, Tel Aviv",
        //     SchoolName = "aaa Aviv University",
        //     HealthInsurance = 12345,
        //     IsPaid = true,
        //     CourseId = 101} };

        //    teachers = new List<Teacher>() {  new Teacher() {  Id = 1,
        //     FirstName = "ff",
        //     LastName = "ff",
        //     Email = "ff.cohen@example.com",
        //     Phone = "050-6666666",
        //     Age = 20,
        //     Address = "ff 14 bb",
        //     YearsOfSeniority=22,
        //    } };
        //    courses = new List<Course>() { new Course() {
        //    Id = 1,
        //    CurrentAmount = 5,
        //    MaxAmount = 20,
        //    DayOnWeek = "ff",
        //    DateStart = new DateTime(2024, 1, 15),
        //    DateEnd = new DateTime(2024, 6, 15),
        //    AmountOfLessons =30,
        //    Type = "ff",
        //    Price = 1000
        //    } };
        //}
    }
}