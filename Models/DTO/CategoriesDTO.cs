namespace BookLibraryAPI.Models.DTO
{
    public class CategoriesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Tag { get; set; }

        public List<string>? ProductNames { get; set; }
    }
    public class CategoriesNoIdDTO
    {
        public string Name { get; set; } = null!;

        public string? Tag { get; set; }
    }
    public class AddCategoriesRequestDTO
    {
        public string Name { get; set; } = null!;

        public string? Tag { get; set; }
    }

}
