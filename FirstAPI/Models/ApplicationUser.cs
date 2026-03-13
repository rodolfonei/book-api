using Microsoft.AspNetCore.Identity;

namespace FirstAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Custom { get; set; }
    }
}
