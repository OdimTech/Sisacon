using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public override void add(Notification notification)
        {
            try
            {
                notification.RegistrationDate = DateTime.Now;

                Context.Notification.Add(notification);
                Context.User.Attach(notification.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Notification getByUserId(int id)
        {
            var notification = new Notification();

            try
            {
                notification = Context.Notification.Where(x => x.User.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return notification;
        }
    }
}
