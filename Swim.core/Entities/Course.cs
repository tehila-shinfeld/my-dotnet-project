namespace Swim.core.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public int CurrentAmount { get; set; }

        public int MaxAmount { get; set; }

        public string DayOnWeek { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int AmountOfLessons { get; set; }

        public string Type { get; set; }

        public int Price { get; set; }

        public List<Student> Students { get; set; }


        public Teacher Teacher { get; set; }

        public int TeacherId { get; set; }
    }
}
