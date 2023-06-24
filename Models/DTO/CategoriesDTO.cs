namespace BookLibraryAPI.Models.DTO
{
    public class CategoriesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Tag { get; set; }

        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
    }
    public class CategoriesNoIdDTO
    {
        public string Name { get; set; } = null!;

        public string? Tag { get; set; }

        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
    }
    public class AddCategoriesRequestDTO
    {
        public string Name { get; set; } = null!;

        public string? Tag { get; set; }
    }

}
