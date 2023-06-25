namespace BookLibraryAPI.Models.DTO
{
    public class AddAuthorDTO
    {
   

            public string? Name { get; set; }

            public string? Nickname { get; set; }

            public int BooksPublished { get; set; }

            public string? Description { get; set; }

            public string? Image { get; set; }

            public string? SocialLink { get; set; }
    }
}
