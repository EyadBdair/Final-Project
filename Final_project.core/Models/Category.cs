using System;
using System.Collections.Generic;

namespace Final_project.Core.Models;

public partial class Category
{
    public decimal CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
}
