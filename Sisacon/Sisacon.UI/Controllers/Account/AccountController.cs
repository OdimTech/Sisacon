using Newtonsoft.Json.Linq;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Enuns;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers.account
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        private readonly IUserAppService _userAppService;

        public AccountController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [Route("user")]
        public HttpResponseMessage RegistrationUser(JObject userCredentials)
        {
            var user = new User();

            user.Active = true;//Essa propriedade deve ser false, mas até o oAuth ser implementado ficará com true
            user.Email = userCredentials["email"].ToString();
            user.eUserType = UserType.eUserType.Single;
            user.ExclusionDate = null;
            user.Password = Helpers.Security.encrypt(userCredentials["pass"].ToString());
            user.LastLogin = null;
            user.ShowWellcomeMessage = true;

            var response = _userAppService.createUser(user);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user")]
        public HttpResponseMessage GetUserById(int id)
        {
            var response = _userAppService.getById(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user")]
        public HttpResponseMessage ValidateEmailInUse(string email)
        {
            var response = _userAppService.emailInUse(email);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user")]
        public HttpResponseMessage Logon(string pass, string email)
        {
            var response = _userAppService.logon(pass, email);

            return Request.CreateResponse(response.StatusCode, response);
        }

        public void GetCountEntities(int userId)
        {
            


        }
    }
}
