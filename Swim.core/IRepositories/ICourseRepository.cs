using Swim.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.core.Repositories
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetAllCourses();

        public Course GetCourseById(int id);

        public Course GetCourseByType(string type);

        public void AddCourse(Course s);

        public Course ChangeCourse(int id, Course s);

        public Course Delete(int id);
    }
}
