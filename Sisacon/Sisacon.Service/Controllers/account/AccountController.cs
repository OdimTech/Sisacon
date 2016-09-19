using Sisacon.BLL;
using Sisacon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers.account
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route("user")]
        public HttpResponseMessage RegistrationUser(User user)
        {
            var userBLL = new UserBLL();

            var addedLines = userBLL.registrationUser(user);

            if(addedLines > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("user")]
        public HttpResponseMessage getUsedEmail()
        {
            var userBLL = new UserBLL();

            var EmailList = userBLL.getUsedEmail();

            return Request.CreateResponse(HttpStatusCode.OK, EmailList);
        }
    }
}
