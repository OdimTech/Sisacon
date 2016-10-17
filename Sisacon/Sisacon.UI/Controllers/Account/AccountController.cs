using Newtonsoft.Json.Linq;
using Sisacon.BLL;
using Sisacon.Domain;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.UI.Controllers.account
{
    [RoutePrefix("api")]
    public class AccountController : BaseController
    {
        [HttpPost]
        [Route("user")]
        public async Task<HttpResponseMessage> RegistrationUser(JObject userCredentials)
        {
            var userBLL = new UserBLL();
            var user = new User();
            var filesBLL = new FilesBLL(ApplicationPath);

            user.Active = true;//Essa propriedade deve ser false, mas até o oAuth ser implementado ficará com true
            user.Email = userCredentials["email"].ToString();
            user.eUserType = eUserType.User;
            user.ExclusionDate = null;
            user.Password = userCredentials["pass"].ToString();
            user.RegistrationDate = DateTime.Now;
            user.LastLogin = null;
            user.ShowWellcomeMessage = true;

            var response = userBLL.registrationUser(user);

            if (response.LogicalTest)
            {
                await filesBLL.createUserPathAsync(user);
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user")]
        public HttpResponseMessage GetUserById(int id)
        {
            var userBLL = new UserBLL();

            var response = userBLL.getUserById(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user")]
        public HttpResponseMessage ValidateEmailInUse(string email)
        {
            var userBLL = new UserBLL();

            var response = userBLL.validateEmailInUse(email);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user")]
        public HttpResponseMessage Logon(string email, string pass)
        {
            var userBLL = new UserBLL();
            var response = new ResponseMessage<User>();

            if (email != string.Empty && pass != string.Empty)
            {
                response = userBLL.logon(pass, email);
            }

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
