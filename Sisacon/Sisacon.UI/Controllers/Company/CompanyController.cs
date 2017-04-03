using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.UI.ViewModels;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class CompanyController : BaseController
    {
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"Content\UserImages";

        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        [HttpPost]
        [Route("company")]
        public HttpResponseMessage Save(CompanyViewModel companyViewModel)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                if (ModelState.IsValid)
                {
                    var company = Mapper.Map<CompanyViewModel, Company>(companyViewModel);

                    response = _companyAppService.saveOrUpdate(company);
                }
                else
                {
                    response = response.createInvalidResponse();
                }
            }
            catch
            {
                response = response.createErrorResponse();
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpPost]
        [Route("company/logo")]
        public HttpResponseMessage AddLogo()
        {
            var response = new ResponseMessage<Company>();

            if (Request.Content.IsMimeMultipartContent("form-data"))
            {
                //var provider = new MultipartFormDataStreamProvider(workingFolder);

                //Request.Content.ReadAsMultipartAsync(provider);

                var context = HttpContext.Current.Request;

                if (context.Files.Count > 0)
                {

                }
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("company")]
        public HttpResponseMessage GetCompanyByUser(int id)
        {
            var response = _companyAppService.getCompanyByUserId(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("company")]
        public HttpResponseMessage GetOccupationArea()
        {
            var response = _companyAppService.getOccupationAreas();

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
