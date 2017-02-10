using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain;
using Sisacon.Domain.Entities;
using Sisacon.UI.ViewModels;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class MaterialController : ApiController
    {
        private readonly IMaterialAppService _materialAppService;

        public MaterialController(IMaterialAppService materialAppService)
        {
            _materialAppService = materialAppService;
        }

        [HttpPost]
        [Route("material")]
        public HttpResponseMessage Save(MaterialViewModel materialViewModel)
        {
            var response = new ResponseMessage<Material>();

            if(ModelState.IsValid)
            {
                var material = Mapper.Map<MaterialViewModel, Material>(materialViewModel);

                response = _materialAppService.saveOrUpdate(material);
            }

            return Request.CreateResponse(response.StatusCode, response);
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
