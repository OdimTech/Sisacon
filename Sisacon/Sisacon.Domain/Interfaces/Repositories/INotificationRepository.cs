using Sisacon.Domain.Entities;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
        Notification getByUserId(int id);
    }
}
