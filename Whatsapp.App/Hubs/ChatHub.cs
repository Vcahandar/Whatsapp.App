using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Whatsapp.App.Models;

namespace Whatsapp.App.Hubs
{
    public class ChatHub:Hub
    {
       readonly UserManager<AppUser> _userManager;
        public ChatHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SendMessage(string message)
        {
          await  Clients.All.SendAsync("ReceiveMessage", message);
        }


        public override  Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var userName = Context.User.Identity.Name;
                var user =  _userManager.FindByNameAsync(userName).Result;
                user.ConnectiionId = Context.ConnectionId;
                 var a=   _userManager.UpdateAsync(user).Result;

                Clients.All.SendAsync("login",user.Id);
            }
          
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var userName = Context.User.Identity.Name;
                var user = _userManager.FindByNameAsync(userName).Result;
                user.ConnectiionId = null;
                var a = _userManager.UpdateAsync(user).Result;
                Clients.All.SendAsync("logout", user.Id);
            }


            return base.OnDisconnectedAsync(exception);
        }
    }
}
