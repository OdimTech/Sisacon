using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class NotificationController : ApiController
    {
        [HttpGet]
        [Route("notify")]
        public HttpResponseMessage GetNotificationsByUserId(int id)
        {
            var response = new ResponseMessage<Notification>();
            var notificationBLL = new NotificationBLL();

            response = notificationBLL.getNotificationsByUserId(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpPut]
        [Route("notify")]
        public HttpResponseMessage Update(int id)
        {
            var response = new ResponseMessage<Notification>();
            var notificationBLL = new NotificationBLL();

            response = notificationBLL.updateStatusVisualized(id);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
