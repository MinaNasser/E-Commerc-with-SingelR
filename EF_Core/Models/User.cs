using Microsoft.AspNetCore.Identity;
namespace EF_Core.Models
{
    public class User : IdentityUser
    {

        public string? FullName { get; set; } = "";
        public virtual Client? Client { get; set; }
        public virtual Vendor? Vendor { get; set; }

    }
}
