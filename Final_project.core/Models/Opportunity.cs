using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class Opportunity
{
    public decimal OpportunityId { get; set; }

    public string? OpportunityTitle { get; set; }

    public string? OpportunityDescription { get; set; }

    public string? OpportunityLocation { get; set; }

    public bool? IsFeatured { get; set; }

    public string? OpportunityDuration { get; set; }

    public string? Qualifications { get; set; }

    public DateTime? ApplicationDeadline { get; set; }

    public string? OpportunityStatus { get; set; }

    public decimal? CategoryId { get; set; }

    public decimal? OpportunityTypeId { get; set; }

    public decimal? Companyid { get; set; }

    public decimal? UserId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Category? Category { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<OpportunitySkill> OpportunitySkills { get; set; } = new List<OpportunitySkill>();

    public virtual OpportunityType? OpportunityType { get; set; }

    public virtual User? User { get; set; }
}
