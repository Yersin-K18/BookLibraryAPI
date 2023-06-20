using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class MenuGroup
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual Menu IdNavigation { get; set; } = null!;
}
