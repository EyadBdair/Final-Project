using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class OpportunityType
{
    public decimal OpportunityTypeId { get; set; }

    public string? OpportunityTypeName { get; set; }

    public string? OpportunityTypeDescription { get; set; }

    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
}
