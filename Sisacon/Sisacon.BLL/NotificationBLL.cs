using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Collections.Generic;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.BLL
{
    public class NotificationBLL
    {
        private NotificationDAL notificationDAL { get; set; }

        public NotificationBLL()
        {
            notificationDAL = new NotificationDAL();
        }

        /// <summary>
        /// Salva uma nova Notificação no banco de dados
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public ResponseMessage<Notification> createNotification(Notification notification)
        {
            var response = new ResponseMessage<Notification>();

            try
            {
                response.Quantity = notificationDAL.createNotification(notification);

                if(response.Quantity > 0)
                {
                    response.LogicalTest = true;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Notification>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Retorna uma lista de Notificações de acordo com o Id do usuario
        /// </summary>
        /// <param name="userId">Id do usuario</param>
        /// <returns></returns>
        public ResponseMessage<Notification> getNotificationsByUserId(int id)
        {
            var response = new ResponseMessage<Notification>();

            try
            {
                response.ValueList = notificationDAL.getNotificationsByUserId(id);

                calcTimeSinceCreation(response.ValueList);
            }
            catch(Exception ex)
            {
                return LogBLL<Notification>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Atualiza o status de Visualizado da notificação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseMessage<Notification> updateStatusVisualized(int id)
        {
            var response = new ResponseMessage<Notification>();

            try
            {
                response.Quantity = notificationDAL.updateStatusVisualized(id);

                if(response.Quantity > 0)
                {
                    response.LogicalTest = true;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Notification>.createLog(ex);
            }

            return response;
        }

        private void calcTimeSinceCreation(List<Notification> listNotifications)
        {
            var timeElapsed = new TimeSpan();

            try
            {
                var atualDate = DateTime.Now;

                foreach(var item in listNotifications)
                {
                    timeElapsed = atualDate - item.CreateDate;

                    if(timeElapsed.Days > 1)
                    {
                        item.TimeSinceCreation = timeElapsed.ToString("d' Dias atrás'");
                    }
                    else if(timeElapsed.Hours > 1)
                    {
                        item.TimeSinceCreation = timeElapsed.ToString("h' Horas atrás'");
                    }
                    else if(timeElapsed.Minutes > 1)
                    {
                        item.TimeSinceCreation = timeElapsed.ToString("m' Minutos atrás'");
                    }
                    else
                    {
                        item.TimeSinceCreation = "Agora mesmo";
                    }
                }
            }
            catch(Exception ex)
            {
                LogBLL<Notification>.createLogNoResponse(ex);
            }
        }

        public void buildNotification(string message, eNotificationClass notificationClass, string link, User user)
        {
            try
            {
                var notification = new Notification();

                notification.Message = message;
                notification.eNotificationClass = notificationClass;
                notification.Link = link;
                notification.User = user;
                notification.CreateDate = DateTime.Now;
                notification.Visualized = false;

                createNotification(notification);

            }
            catch(Exception ex)
            {

                LogBLL<string>.createLogNoResponse(ex);
            }
        }
    }
}
