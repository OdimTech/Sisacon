using Sisacon.Domain.Entities;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface INotificationService : IServiceBase<Notification>
    {
        Notification getByUserId(int id);
    }
}
