using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime DateOrder { get; set; }

    public decimal Total { get; set; }

    public double? Discount { get; set; }

    public int? UserId { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual User? User { get; set; }
}
