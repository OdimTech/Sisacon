using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.Interfaces.Services;
using System;

namespace Sisacon.Domain.Services
{
    public class NotificationService : ServiceBase<Notification>, INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Notification getByUserId(int id)
        {
            try
            {
                return _repository.getByUserId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
