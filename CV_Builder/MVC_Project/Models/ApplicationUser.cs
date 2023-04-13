using Microsoft.AspNetCore.Identity;

namespace Final.Models
{
    public class ApplicationUser:IdentityUser
    {
        public byte[] image { get; set; }
    }
}
