//using Sisacon.BLL;
//using Sisacon.Domain;
//using System.Net.Http;
//using System.Web.Http;

//namespace Sisacon.UI.Controllers.Configuration
//{
//    [RoutePrefix("api")]
//    public class ConfigurationController : ApiController
//    {
//        [HttpGet]
//        [Route("config")]  
//        public HttpResponseMessage GetConfigurationByUserId(int idUser)
//        {
//            var configBLL = new ConfigurationBLL();

//            var response = configBLL.getConfiguratioByIdUser(idUser);

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpPost]
//        [Route("config")]
//        public HttpResponseMessage save(Domain.Configuration config)
//        {
//            var configBLL = new ConfigurationBLL();
//            var response = new ResponseMessage<Domain.Configuration>();

//            if(config != null)
//            {
//                if(config.Id > 0)
//                {
//                    response = configBLL.update(config);
//                }
//                else
//                {
//                    response = configBLL.save(config);
//                }
//            }

//            return Request.CreateResponse(response.StatusCode, response);
//        }
//    }
//}
