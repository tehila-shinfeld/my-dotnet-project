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
            return dataCourse.courses.Include(c => c.Teacher).Include( t=>t.Students);
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
                courseToChange = c;
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
