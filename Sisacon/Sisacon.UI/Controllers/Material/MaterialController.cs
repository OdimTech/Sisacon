//using Sisacon.BLL;
//using Sisacon.Domain;
//using System.Net.Http;
//using System.Web.Http;

//namespace Sisacon.UI.Controllers
//{
//    [RoutePrefix("api")]
//    public class MaterialController : ApiController
//    {
//        [HttpPost]
//        [Route("material")]
//        public HttpResponseMessage Save(Material material)
//        {
//            var materialBLL = new MaterialBLL();
//            var response = new ResponseMessage<Material>();

//            if(material.Id == 0)
//            {
//                response = materialBLL.save(material);
//            }
//            else
//            {
//                response = materialBLL.update(material);
//            }

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpDelete]
//        [Route("material")]
//        public HttpResponseMessage Delete(int id)
//        {
//            var materialBLL = new MaterialBLL();
//            var response = new ResponseMessage<Material>();

//            response = materialBLL.delete(id);

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpGet]
//        [Route("material")]
//        public HttpResponseMessage GetMaterialById(int id)
//        {
//            var materialBLL = new MaterialBLL();
//            var response = new ResponseMessage<Material>();

//            response = materialBLL.getMaterialById(id);

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpGet]
//        [Route("material")]
//        public HttpResponseMessage GetMaterialByUserId(int userId)
//        {
//            var materialBLL = new MaterialBLL();
//            var response = new ResponseMessage<Material>();

//            response = materialBLL.getMaterialsByUserId(userId);

//            return Request.CreateResponse(response.StatusCode, response);
//        }

//        [HttpGet]
//        [Route("material")]
//        public HttpResponseMessage GetMaterialByCategory(int idCategory)
//        {
//            var materialBLL = new MaterialBLL();
//            var response = new ResponseMessage<Material>();

//            response = materialBLL.getMaterialsByCategory(idCategory);

//            return Request.CreateResponse(response.StatusCode, response);
//        }
//    }
//}
