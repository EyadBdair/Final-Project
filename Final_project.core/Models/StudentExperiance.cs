using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class StudentExperiance
{
    public decimal ExperienceId { get; set; }

    public string? ExperienceTitle { get; set; }

    public string? ExperienceOrganization { get; set; }

    public DateTime? ExperienceStartdate { get; set; }

    public DateTime? ExperienceEnddate { get; set; }

    public decimal? UserId { get; set; }

    public virtual User? User { get; set; }
}
