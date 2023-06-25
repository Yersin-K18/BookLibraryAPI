using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models.Domain;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Tag { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
