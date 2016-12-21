using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers.SystemConfiguration
{
    [RoutePrefix("api")]
    public class ConfigurationController : ApiController
    {
        private readonly IConfigurationAppService _configAppService;

        public ConfigurationController(IConfigurationAppService configService)
        {
            _configAppService = configService;
        }

        [HttpGet]
        [Route("config")]
        public HttpResponseMessage GetConfigurationByUserId(int idUser)
        {
            var response = _configAppService.getByUserId(idUser);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpPost]
        [Route("config")]
        public HttpResponseMessage save(Configuration config)
        {
            var response = new ResponseMessage<Configuration>();

            if (ModelState.IsValid)
            {
                if (config != null)
                {
                    if (config.Id > 0)
                    {
                        response = _configAppService.update(config);
                    }
                    else
                    {
                        response = configBLL.save(config);
                    }
                }
            }

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
