namespace Swim.core.Entities
{
    public class Student : Person
    {

        public string SchoolName { get; set; }

        public int HealthInsurance { get; set; }

        public bool IsPaid { get; set; }
        
        public List<Course> Courses { get; set; }

        //public Student() { }

        //public Student(string schoolName, int healthInsurance, bool isPaid, Course course) : base()
        //{
        //    SchoolName = schoolName;
        //    HealthInsurance = healthInsurance;
        //    IsPaid = isPaid;
        //    Course = course;
        //}
    }
}
