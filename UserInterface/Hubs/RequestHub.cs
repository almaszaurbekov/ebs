using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace UserInterface.Hubs
{
    [Authorize]
    public class RequestHub : Hub
    {
        public async Task Send(string name, string book)
        {
            await this.Clients.All.SendAsync(name, book);
        }
    }
}