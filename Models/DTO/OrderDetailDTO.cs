namespace BookLibraryAPI.Models.DTO
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }
    }

    public class OrderDetailNoIdDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
