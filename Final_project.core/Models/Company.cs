using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class Company
{
    public decimal Companyid { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyDescription { get; set; }

    public string? CompanyEmail { get; set; }

    public DateTime? CompanyCreatedAt { get; set; }

    public string? CompanyWebsite { get; set; }

    public string? CompanyLocation { get; set; }

    public decimal? CompanyPhone { get; set; }

    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
}
