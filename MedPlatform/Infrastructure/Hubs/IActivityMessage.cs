using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    public interface IActivityMessage
    {
        Task SendMessage(ActivityMessage message);
    }
}
