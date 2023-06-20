using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class SupportOnline
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public string? Skype { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Yahoo { get; set; }

    public string? Facebook { get; set; }

    public bool? Status { get; set; }
}
