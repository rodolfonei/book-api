using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FirstAPI.Data
{
    public class FirstAPIContext : IdentityDbContext<ApplicationUser>
    {
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options): base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
