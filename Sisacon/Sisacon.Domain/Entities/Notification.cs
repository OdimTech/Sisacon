using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.NotificationClass;

namespace Sisacon.Domain.Entities
{
    public class Notification : BaseEntity
    {
        #region Propeties

        public string Message { get; set; }
        public string TimeSinceCreation { get; set; }
        private eNotificationClass eNotificationClass { get; set; }
        public string Link { get; set; }
        public string NotificationClassCSS
        {
            get
            {
                switch (eNotificationClass)
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
        public virtual User User { get; set; }

        #endregion
    }
}
