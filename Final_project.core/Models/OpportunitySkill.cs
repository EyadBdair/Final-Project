using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class OpportunitySkill
{
    public decimal OpportunitySkillId { get; set; }

    public string? OpportunitySkillName { get; set; }

    public decimal? OpportunityId { get; set; }

    public virtual Opportunity? Opportunity { get; set; }
}
