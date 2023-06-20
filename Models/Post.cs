using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

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

    public virtual PostCategory? Category { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
