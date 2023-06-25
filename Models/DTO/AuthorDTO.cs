namespace BookLibraryAPI.Models.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Nickname { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? SocialLink { get; set; }
        public List<string> ProductNames { get; set; }
    }
    public class AuthorNoIdDTO
    {
        
        public string? Name { get; set; }

        public string? Nickname { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? SocialLink { get; set; }
        public List<string> ProductNames { get; set; }
    }
    public class AddAuthorRequestDTO
    {
        

        public string? Name { get; set; }

        public string? Nickname { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? SocialLink { get; set; }
    }
}
