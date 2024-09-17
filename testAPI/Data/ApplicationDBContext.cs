using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testAPI.Models;

namespace testAPI.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        { 
        }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                 new IdentityRole
                 {
                     Name = "Admin",
                     NormalizedName = "ADMIN"
                 },
                 new IdentityRole
                 {
                     Name = "User",
                     NormalizedName = "USER"
                 }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
