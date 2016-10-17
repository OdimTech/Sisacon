using System;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.Domain
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public string TimeSinceCreation { get; set; }
        public eNotificationClass eNotificationClass { get; set; }
        public string Link { get; set; }
        public string NotificationClassCSS
        {
            get
            {
                switch(eNotificationClass)
                {
                    case eNotificationClass.Red:
                        {
                            return "red";
                        }
                    case eNotificationClass.Yellow:
                        {
                            return "yellow";
                        }
                    case eNotificationClass.Green:
                        {
                            return "green";
                        }
                    default:
                        return "green";
                }
            }

        }
        public bool Visualized { get; set; }
        public User User { get; set; }
    }
}
