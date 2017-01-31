using Sisacon.Domain;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class MaterialController : ApiController
    {
        [HttpPost]
        [Route("material")]
        public HttpResponseMessage Save()
        {

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "");
        }

        [HttpDelete]
        [Route("material")]
        public HttpResponseMessage Delete(int id)
        {

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "");
        }

        [HttpGet]
        [Route("material")]
        public HttpResponseMessage GetMaterialById(int id)
        {

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "");
        }

        [HttpGet]
        [Route("material")]
        public HttpResponseMessage GetMaterialByUserId(int userId)
        {

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "");
        }

        [HttpGet]
        [Route("material")]
        public HttpResponseMessage GetMaterialByCategory(int idCategory)
        {

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "");
        }
    }
}
