using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class Tag
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
