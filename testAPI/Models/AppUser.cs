using Microsoft.AspNetCore.Identity;

namespace testAPI.Models
{
    public class AppUser : IdentityUser
    {
        public List<Product> Portfolios { get; set; } = new List<Product>();
    }
}
