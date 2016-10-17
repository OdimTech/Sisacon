using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class NotificationDAL
    {
        /// <summary>
        /// Salva uma nova Notificação no banco de dados
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public int createNotification(Notification notification)
        {
            var addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.User.Attach(notification.User);
                    context.Notification.Add(notification);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        /// <summary>
        /// Retorna uma lista de Notificações de acordo com o Id do usuario
        /// </summary>
        /// <param name="userId">Id do usuario</param>
        /// <returns></returns>
        public List<Notification> getNotificationsByUserId(int userId)
        {
            var listNotifications = new List<Notification>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    listNotifications = context.Notification
                        .Where(x => x.User.Id == userId && x.Visualized == false)
                        .OrderBy(x => x.eNotificationClass)
                        .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return listNotifications;
        }

        /// <summary>
        /// Atualiza o status de Visualizado da notificação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int updateStatusVisualized(int id)
        {
            var updatedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    var notification = context.Notification.Where(x => x.Id == id).FirstOrDefault();

                    if(notification != null)
                    {
                        notification.Visualized = true;
                        context.Entry(notification).State = EntityState.Modified;
                        updatedLines = context.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return updatedLines;
        }
    }
}
