using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string CustomerMobile { get; set; } = null!;

    public string? CustomerMassage { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymenStatus { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
