using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace UserInterface.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string email, string message)
        {
            await this.Clients.All.SendAsync("Send", email, message);
        }
    }
}