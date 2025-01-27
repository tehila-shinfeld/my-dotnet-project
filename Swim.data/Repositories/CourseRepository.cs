using Microsoft.EntityFrameworkCore;
using Swim.core.Entities;
using Swim.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Swim.data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext dataCourse;

        public CourseRepository(DataContext data)
        {
            dataCourse = data;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return  dataCourse.courses.Include(c => c.Teacher).Include(t => t.Students);
        }

        public Course GetCourseById(int id)
        {
            var c = dataCourse.courses.ToList().Find(t => t.Id == id);
            return c;
        }

        public Course GetCourseByType(string type)
        {
            var course = dataCourse.courses.ToList().Find(c => c.Type.ToLower() == type.ToLower());
            return course;
        }

        public void AddCourse(Course c)
        {
            dataCourse.courses.Add(c);
        }

        public Course ChangeCourse(int id, Course c)
        {
            var courseToChange = dataCourse.courses.FirstOrDefault(c => c.Id == id);
            if (courseToChange != null)
            {
                // עדכון שדות האובייקט הקיים
                courseToChange.CurrentAmount = c.CurrentAmount;
                courseToChange.MaxAmount = c.MaxAmount;
                courseToChange.DayOnWeek = c.DayOnWeek;
                courseToChange.DateStart = c.DateStart;
                courseToChange.DateEnd = c.DateEnd;
                courseToChange.AmountOfLessons = c.AmountOfLessons;
                courseToChange.Type = c.Type;
                courseToChange.Price = c.Price;
                courseToChange.TeacherId = c.TeacherId;

                // עדכון הרשימה של הסטודנטים (למשל, אם מחליפים את כל הרשימה)
                courseToChange.Students = c.Students ?? new List<Student>();

                // עדכון האובייקט של המורה
                courseToChange.Teacher = c.Teacher ?? new Teacher();

                return courseToChange;
            }
            return null;

        }

        public Course Delete(int id)
        {
            var c = dataCourse.courses.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                dataCourse.courses.Remove(c);
                return c;
            }
            return null;
        }
    }
}
