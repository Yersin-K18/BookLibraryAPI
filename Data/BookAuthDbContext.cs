using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Data
{
    public class BookAuthDbContext : IdentityDbContext
    {
        public BookAuthDbContext(DbContextOptions<BookAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var readerRoleId = "3af66078-e066-41d1-b87a-df3a90361536";
            var writeRoleId = "7b8d7d39-e0a7-4fc2-89f9-a64545369fde";

            base.OnModelCreating(builder);

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Read",
                    NormalizedName = "Read".ToUpper()
                },
                new IdentityRole
                {
                    Id = writeRoleId,
                    ConcurrencyStamp = writeRoleId,
                    Name = "Write",
                    NormalizedName = "Write".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
