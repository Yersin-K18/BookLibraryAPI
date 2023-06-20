using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class ProductsCategory
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

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
