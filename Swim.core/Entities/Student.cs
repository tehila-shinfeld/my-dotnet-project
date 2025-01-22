namespace Swim.core.Entities
{
    public class Student : Person
    {

        public string SchoolName { get; set; }

        public int HealthInsurance { get; set; }

        public bool IsPaid { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
