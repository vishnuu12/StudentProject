using System.ComponentModel.DataAnnotations;

namespace StudentProject.Dto
{
    public class StudentVM
    {
        public int StudentId { get; set; }
        public int MarksId { get; set; }

        public string StudentName { get; set; } = null!;

        public string? Class { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public int? Tamil { get; set; }

        public int? English { get; set; }

        public int? Maths { get; set; }
    }
}
