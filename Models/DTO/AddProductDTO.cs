namespace BookLibraryAPI.Models.DTO
{
    public class AddProductDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public int? CategorieId { get; set; }

        public string? Language { get; set; }

        public string? Image { get; set; }

        public int? AuthorId { get; set; }

        public int? Quantity { get; set; }

    }
}
