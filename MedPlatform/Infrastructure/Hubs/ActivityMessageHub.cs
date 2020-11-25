using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    public class ActivityMessageHub : Hub<IActivityMessageHub>
    {
        public async Task SendMessageToClient(ActivityMessage message)
        {
            await Clients.All.SendMessage(message);
        }
    }
}
