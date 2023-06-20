using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class SystemConfig
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? ValueString { get; set; }

    public int? ValueInt { get; set; }
}
