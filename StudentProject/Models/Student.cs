namespace StudentProject.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = null!;

        public string? Class { get; set; }

        public DateTime? DOB { get; set; }

        public virtual ICollection<Marks> Marks { get; set; } = new List<Marks>();
    }
}
