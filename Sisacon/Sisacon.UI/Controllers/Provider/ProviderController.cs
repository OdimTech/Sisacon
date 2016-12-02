//using Sisacon.BLL;
//using Sisacon.Domain;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Web.Http;

//namespace Sisacon.UI.Controllers
//{
//    [RoutePrefix("api")]
//    public class ProviderController : ApiController
//    {
//        [HttpPost]
//        [Route("provider")]
//        public HttpResponseMessage Save(Provider provider)
//        {
//            var response = new ResponseMessage<Provider>();
//            var providerBLL = new ProviderBLL();

//            if(provider != null)
//            {
//                if(provider.Id == 0)
//                {
//                    response = providerBLL.save(provider);
//                }
//                else
//                {
//                    response = providerBLL.update(provider);
//                }
//            }

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpGet]
//        [Route("provider")]
//        public HttpResponseMessage GetProvidersByUserId(int userId)
//        {
//            var response = new ResponseMessage<List<Provider>>();
//            var providerBLL = new ProviderBLL();

//            response = providerBLL.getProvidersByUserId(userId);

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpGet]
//        [Route("provider")]
//        public HttpResponseMessage GetProviderById(int id)
//        {
//            var response = new ResponseMessage<Provider>();
//            var providerBLL = new ProviderBLL();

//            response = providerBLL.getProviderById(id);

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpDelete]
//        [Route("provider")]
//        public HttpResponseMessage Delete(int id)
//        {
//            var response = new ResponseMessage<Provider>();
//            var providerBLL = new ProviderBLL();

//            response = providerBLL.delete(id);

//            return Request.CreateResponse(response.StatusCode, response);
//        }
//    }
//}
