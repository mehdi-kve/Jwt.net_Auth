using Microsoft.EntityFrameworkCore;
using testAPI.Models;

namespace testAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        { 
        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
