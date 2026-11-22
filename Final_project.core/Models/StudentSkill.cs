using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class StudentSkill
{
    public decimal StudentSkillid { get; set; }

    public string? SkillName { get; set; }

    public string? SkillLevel { get; set; }

    public decimal? UserId { get; set; }

    public virtual User? User { get; set; }
}
