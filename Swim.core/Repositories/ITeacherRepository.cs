using Swim.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.core.Repositories
{
    public interface ITeacherRepository
    {
        public IEnumerable<Teacher> GetAllTeachers();

        public Teacher GetTeacherById(int id);

        public Teacher GetTeacherByName(string name);

        public void AddTeacher(Teacher s);

        public Teacher ChangeTeacher(int id, Teacher s);

        public Teacher Delete(int id);
    }
}
