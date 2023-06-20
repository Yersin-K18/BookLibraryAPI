using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Image { get; set; }

    public string? MoreImages { get; set; }

    public decimal? Promotion { get; set; }

    public decimal Price { get; set; }

    public int? Warranty { get; set; }

    public string? Decription { get; set; }

    public string? Content { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public bool Status { get; set; }

    public bool? HomeFlag { get; set; }

    public bool? HotFlag { get; set; }

    public int? ViewCount { get; set; }

    public virtual ProductsCategory? Category { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
