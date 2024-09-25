using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
