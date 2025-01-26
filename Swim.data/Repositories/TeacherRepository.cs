using Microsoft.EntityFrameworkCore;
using Swim.core.Entities;
using Swim.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.data.Repositories
{
    public class TeacherRepository :ITeacherRepository
    {
        private readonly DataContext Data;

        public TeacherRepository(DataContext dataContext)
        {
            Data = dataContext;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return Data.teachers.Include(c => c.Courses);
        }

        public Teacher GetTeacherById(int id)
        {
            var t = Data.teachers.ToList().Find(t => t.Id == id);
            return t;
        }

        public Teacher GetTeacherByName(string name)
        {
            var teacher = Data.teachers.ToList().Find(t => t.FirstName.ToLower() == name.ToLower());
            return teacher;
        }

        public void AddTeacher(Teacher t)
        {
            if (t != null)
            {
                Data.teachers.Add(t);
            }
        }

        public Teacher ChangeTeacher(int id, Teacher t)
        {
            var teacherToChange = Data.teachers.FirstOrDefault(t => t.Id == id);
            if (teacherToChange != null)
            {
                teacherToChange = t;
                return teacherToChange;
            }
            return null;
        }

        public Teacher Delete(int id)
        {
            // נתק את המורה מכל הקורסים שלו
            var courses = Data.courses.Where(c => c.TeacherId == id).ToList();
            foreach (var course in courses)
            {
                course.TeacherId = null;
            }

            // מחק את המורה
            var teacher = Data.teachers.Find(id);
            if (teacher != null)
            {
                Data.teachers.Remove(teacher);
                return teacher;

            }

            Data.SaveChanges();
            return null;

        }
    }
}
