namespace BookLibraryAPI.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime DateOrder { get; set; }

        public decimal Total { get; set; }

        public double? Discount { get; set; }

        public string? UserFullName { get; set; }

        public string Address { get; set; } = null!;
        public List<string>? ProductNames { get; set; }
    }
}
