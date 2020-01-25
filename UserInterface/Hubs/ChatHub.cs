using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace UserInterface.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            var user = Context.User;
            await this.Clients.All.SendAsync("Send", user.Identity.Name);
        }
    }
}
