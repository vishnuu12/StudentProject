using StudentProject.Models;

namespace StudentProject.Dto
{
    public class MarkDto
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int? Tamil { get; set; }

        public int? English { get; set; }

        public int? Maths { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
