using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class StudentProfile
{
    public decimal StudentId { get; set; }

    public string? StudentUniversity { get; set; }

    public string? StudentMajor { get; set; }

    public byte? GraduationYear { get; set; }

    public string? StudentBio { get; set; }

    public string? CvFilePath { get; set; }

    public decimal? UserId { get; set; }

    public virtual User? User { get; set; }
}
