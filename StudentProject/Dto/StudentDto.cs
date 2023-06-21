using StudentProject.Models;

namespace StudentProject.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = null!;

        public string? Class { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Marks> Marks { get; set; } = new List<Marks>();
    }
}
