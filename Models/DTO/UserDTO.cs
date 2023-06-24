namespace BookLibraryAPI.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Sdt { get; set; }

        public string? DiaChi { get; set; }

        public string? MaSoThue { get; set; }
        public List<int>? Orders { get; set; }

    }

    public class UserNoIdDTO
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Sdt { get; set; }

        public string? DiaChi { get; set; }

        public string? MaSoThue { get; set; }
        public List<int>? Orders { get; set; }
    }
}
