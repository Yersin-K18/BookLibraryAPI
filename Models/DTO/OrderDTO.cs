namespace BookLibraryAPI.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime DateOrder { get; set; }

        public decimal Total { get; set; }

        public double? Discount { get; set; }

        public string Address { get; set; } = null!;
        public string UserName{ get; set; }
        public List<int> OrderDetailIds { get; set; }
        public List<string>? ProductNames { get; set; }
    }
    
    public class OrderNoIdDTO
    {

        public DateTime DateOrder { get; set; }
        public decimal Total { get; set; }
        public double? Discount { get; set; }
        public string Address { get; set; } = null!;
        public int UserId { get; set; }

    }
}
