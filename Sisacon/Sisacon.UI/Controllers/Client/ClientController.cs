//using Sisacon.BLL;
//using Sisacon.Domain;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Web.Http;

//namespace Sisacon.UI.Controllers
//{
//    [RoutePrefix("api")]
//    public class ClientController : ApiController
//    {
//        [HttpPost]
//        [Route("client")]
//        public HttpResponseMessage Save(Client client)
//        {
//            var response = new ResponseMessage<Client>();
//            var clientBLL = new ClientBLL();

//            if(client != null)
//            {
//                if(client.Id >0)
//                {
//                    response = clientBLL.update(client);
//                }
//                else
//                {
//                    response = clientBLL.save(client);
//                }
//            }

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpGet]
//        [Route("client")]
//        public HttpResponseMessage GetClientById(int id)
//        {
//            var response = new ResponseMessage<Client>();
//            var clientBLL = new ClientBLL();

//            response = clientBLL.getClientById(id);

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpGet]
//        [Route("client")]
//        public HttpResponseMessage GetClientByUserId(int idUser)
//        {
//            var response = new ResponseMessage<List<Client>>();
//            var clientBLL = new ClientBLL();

//            response = clientBLL.getClientListByUser(idUser);

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpDelete]
//        [Route("client")]
//        public HttpResponseMessage DeleteClient(int idClient)
//        {
//            var response = new ResponseMessage<Client>();
//            var clientBLL = new ClientBLL();

//            response = clientBLL.delete(idClient);

//            return Request.CreateResponse(response.StatusCode, response);
//        }
//    }
//}
