namespace Swim.core.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public int CurrentAmount { get; set; }

        public int MaxAmount { get; set; }

        public string DayOnWeek { get; set; }

        public string DateStart { get; set; }

        public string DateEnd { get; set; }

        public int AmountOfLessons { get; set; }

        public string Type { get; set; }

        public int Price { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public Teacher Teacher { get; set; } = new Teacher();

        public int TeacherId { get; set; }
    }
}
