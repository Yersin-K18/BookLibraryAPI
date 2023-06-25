using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models.Domain;

public partial class Author
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Nickname { get; set; }

    public int BooksPublished { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? SocialLink { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
