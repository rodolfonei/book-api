using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FirstAPI.Data
{
    public class FirstAPIContext : IdentityDbContext<ApplicationUser>
    {
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options): base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER"},
                new IdentityRole { Id = "3", Name = "Default", NormalizedName = "DEFAULT" }
            );       
        }
    }
}
