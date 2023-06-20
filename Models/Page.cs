using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class Page
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public bool? Status { get; set; }
}
