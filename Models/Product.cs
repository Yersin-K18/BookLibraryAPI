namespace BookLibraryAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public int? CategorieId { get; set; }

    public string? Language { get; set; }

    public string? Image { get; set; }

    public int? AuthorId { get; set; }

    public int? Quantity { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Category? Categorie { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
