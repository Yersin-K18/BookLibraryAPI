using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibraryAPI.Models.Domain;

public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? MaSoThue { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
