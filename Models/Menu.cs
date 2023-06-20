using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Url { get; set; }

    public int? DisplayOrder { get; set; }

    public int? GroupId { get; set; }

    public string? Targer { get; set; }

    public bool? Status { get; set; }

    public virtual MenuGroup? MenuGroup { get; set; }
}
