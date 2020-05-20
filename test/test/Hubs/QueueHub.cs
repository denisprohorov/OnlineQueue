using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRApp
{
    public class QueueHub : Hub
    {
        public async Task SendGroupNotify(string group)
        {
            await Clients.Group(group).SendAsync("GetNotify");
        }
        public async Task AddToGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }
    }
}