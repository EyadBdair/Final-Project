using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class User
{
    public decimal UserId { get; set; }

    public string UserEmail { get; set; } = null!;

    public string? UserFullName { get; set; }

    public string? UserPhone { get; set; }

    public string? UserPasswordHash { get; set; }

    public string? UserRole { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();

    public virtual ICollection<StudentExperiance> StudentExperiances { get; set; } = new List<StudentExperiance>();

    public virtual StudentProfile? StudentProfile { get; set; }

    public virtual ICollection<StudentSkill> StudentSkills { get; set; } = new List<StudentSkill>();
}
