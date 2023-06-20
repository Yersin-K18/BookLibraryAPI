using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class PostCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public string? Description { get; set; }

    public int? ParentId { get; set; }

    public int? DisplayOrder { get; set; }

    public string? Images { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdateBy { get; set; }

    public bool Status { get; set; }

    public bool? HomeFlag { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
