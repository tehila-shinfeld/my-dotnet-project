using Microsoft.EntityFrameworkCore;
using Swim.core.Entities;
using Swim.Core.Repositories;

namespace Swim.data.Repositories
{
    //פעילות של התממשקות מטל האאטה בייס וזה התפפקיד של שכבת הדאטה

    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext studentsData;

        public StudentRepository(DataContext dataContext)
        {
            studentsData = dataContext;
        }
        //======================================================

        public IEnumerable<Student> GetAllStudents()
        {
            return studentsData.students.Include(s => s.Courses);
        }

        public Student GetStudentById(int id)
        {
            var student = studentsData.students.ToList().Find(s => s.Id == id);
            return student;
        }

        public Student GetStudentByName(string name)
        {
            var student = studentsData.students.ToList().Find(s => s.FirstName.ToLower() == name.ToLower());
            return student;
        }

        public void AddStudent(Student s)
        {
            studentsData.students.Add(s);
        }

        public Student ChangeStudent(int id, Student s)
        {
            var studentToChange = studentsData.students.FirstOrDefault(st => st.Id == id);
            if (studentToChange != null)
            {
                // עדכון השדות של האובייקט הקיים
                studentToChange.FirstName = s.FirstName;
                studentToChange.LastName = s.LastName;
                studentToChange.Courses = s.Courses;
                studentToChange.HealthInsurance = s.HealthInsurance;
                studentToChange.IsPaid = s.IsPaid;
                studentToChange.Id = s.Id;
                studentToChange.Address = s.Address;
                studentToChange.SchoolName = s.SchoolName;
                studentToChange.Email = s.Email;
                // הוסף שדות נוספים לפי הצורך
                return studentToChange;
            }
            return null;
        }
        public Student Delete(int id)
        {
            var s = studentsData.students.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                studentsData.students.Remove(s);
                return s;
            }
            return null;
        }
    }
}
