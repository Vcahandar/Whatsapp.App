using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Whatsapp.App.Models;

namespace Whatsapp.App.Contexts
{
    public class ChatDbContext:IdentityDbContext<AppUser>
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options):base(options)
        {
                
        }
    }
}
