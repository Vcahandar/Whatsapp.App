using Microsoft.AspNetCore.Identity;

namespace Whatsapp.App.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public string? ConnectiionId { get; set; }
    }
}
