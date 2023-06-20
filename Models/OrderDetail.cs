using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quanlity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ProductsCategory Product { get; set; } = null!;
}
