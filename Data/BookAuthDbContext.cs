using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Data
{
    public class BookAuthDbContext : IdentityDbContext
    {
        public BookAuthDbContext(DbContextOptions<BookAuthDbContext> options) : base(options)
        {
        }
    }
}
