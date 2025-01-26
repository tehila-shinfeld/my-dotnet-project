using Swim.core.Entities;
namespace Swim.Core.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();

        Student GetStudentById(int id);

        public Student GetStudentByName(string name);

        public void AddStudent(Student s);

        public Student ChangeStudent(int id, Student s);

        public Student Delete(int id);
    }
}

