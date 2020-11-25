using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    public interface IActivityMessageHub
    {
        Task SendMessage(ActivityMessage message);
    }
}
