using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class Application
{
    public decimal ApplicationId { get; set; }

    public string? CoverLetter { get; set; }

    public DateTime? ApplicationDate { get; set; }

    public decimal? StatusId { get; set; }

    public decimal? UserId { get; set; }

    public decimal? OpportunityId { get; set; }

    public virtual Opportunity? Opportunity { get; set; }

    public virtual ApplicationStatus? Status { get; set; }

    public virtual User? User { get; set; }
}
