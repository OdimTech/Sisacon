﻿using AutoMapper;
using Newtonsoft.Json.Linq;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Enuns;
using Sisacon.Domain.ValueObjects;
using System.Net.Http;
using System.Threading.Tasks;
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
            user.Email = new Email();

            user.Active = true;//Essa propriedade deve ser false, mas até o oAuth ser implementado ficará com true
            user.Email.Address = userCredentials["email"].ToString();
            user.eUserType = UserType.eUserType.Single;
            user.ExclusionDate = null;
            user.Password = userCredentials["pass"].ToString();
            user.LastLogin = null;
            user.ShowWellcomeMessage = true;

            var response = _userAppService.createUser(user);

            if (response.LogicalTest)
            {
                //await filesBLL.createUserPathAsync(user);
            }

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
    }
}
