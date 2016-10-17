using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.BLL;
using Sisacon.Domain;

namespace Sisacon.Tests.BLL
{
    [TestClass]
    public class NotificationBLLTests
    {
        public Notification notification { get; set; }
        public NotificationBLL notificationBLL { get; set; }

        [TestInitialize]
        public void init()
        {
            notification = new Notification();
            notificationBLL = new NotificationBLL();
        }

        [TestMethod]
        public void getNotificationsByUserId()
        {
            var notifications = notificationBLL.getNotificationsByUserId(3);

            Assert.IsNotNull(notifications);
        }
    }
}
