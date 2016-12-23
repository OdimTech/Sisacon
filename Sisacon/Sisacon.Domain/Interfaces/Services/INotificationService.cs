using Sisacon.Domain.Entities;
using static Sisacon.Domain.Enuns.NotificationClass;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface INotificationService : IServiceBase<Notification>
    {
        Notification getByUserId(int id);
        Notification buildNotification(string message, eNotificationClass notificationClass, string link, User user);
    }
}
