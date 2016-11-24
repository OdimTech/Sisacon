using Sisacon.BLL;
using Sisacon.Domain;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class MaterialCategoryController : ApiController
    {
        [HttpPost]
        [Route("materialCategory")]
        public HttpResponseMessage Save(MaterialCategory category)
        {
            var materialCategoryBLL = new MaterialCategoryBLL();
            var response = new ResponseMessage<MaterialCategory>();

            if(category != null)
            {
                if(category.Id == 0)
                {
                    response = materialCategoryBLL.save(category);
                }
                else
                {
                    response = materialCategoryBLL.update(category);
                }
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("materialCategory")]
        public HttpResponseMessage GetMaterialsCategories(int userId)
        {
            var materialCategoryBLL = new MaterialCategoryBLL();
            var response = new ResponseMessage<MaterialCategory>();

            if(userId > 0)
            {
                response = materialCategoryBLL.getCategoriesByUserId(userId);
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("materialCategory")]
        public HttpResponseMessage GetMaterialCategoryById(int id)
        {
            var materialCategoryBLL = new MaterialCategoryBLL();
            var response = new ResponseMessage<MaterialCategory>();

            if(id > 0)
            {
                response = materialCategoryBLL.getCategoriesById(id);
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("materialCategory")]
        public HttpResponseMessage Delete(int categoryId)
        {
            var materialCategoryBLL = new MaterialCategoryBLL();
            var response = new ResponseMessage<MaterialCategory>();

            if(categoryId > 0)
            {
                response = materialCategoryBLL.delete(categoryId);
            }
            else
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
