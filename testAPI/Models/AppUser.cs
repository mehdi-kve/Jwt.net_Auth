using Microsoft.AspNetCore.Identity;

namespace testAPI.Models
{
    public class AppUser : IdentityUser
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
