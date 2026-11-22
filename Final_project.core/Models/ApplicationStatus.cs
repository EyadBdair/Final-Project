using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class ApplicationStatus
{
    public decimal StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public string? StatusDescription { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
