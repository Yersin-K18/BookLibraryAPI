using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Models;

public partial class User 
{
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
