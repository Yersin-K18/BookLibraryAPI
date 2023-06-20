using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class VisitorStatistic
{
    public Guid Id { get; set; }

    public DateTime VisitedDate { get; set; }

    public string IpAddress { get; set; } = null!;
}
