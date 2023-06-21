using System;
using System.Collections.Generic;

namespace StudentProject.Models;

public partial class Marks
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int? Tamil { get; set; }

    public int? English { get; set; }

    public int? Maths { get; set; }

    public virtual Student Student { get; set; } = null!;
}
