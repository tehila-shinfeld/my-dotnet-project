namespace Swim.core.Entities
{
    public class Teacher : Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int YearsOfSeniority { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}