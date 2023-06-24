namespace BookLibraryAPI.Models.DTO
{
    public class AddOrderDTO
    {
        public DateTime DateOrder { get; set; }

        public decimal Total { get; set; }

        public double? Discount { get; set; }

        public int? UserId { get; set; }

        public string Address { get; set; } = null!;
        public List<int>? ProductId { get; set; }
    }
}
