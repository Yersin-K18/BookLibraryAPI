namespace BookLibraryAPI.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public string? Language { get; set; }

        public string? Image { get; set; }


        public int? Quantity { get; set; }

        public virtual string? AuthorName { get; set; }

        public virtual string?  CategoriesName { get; set; }
    }
}
