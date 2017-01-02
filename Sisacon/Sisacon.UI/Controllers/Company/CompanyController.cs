using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class CompanyController : BaseController
    {
        //private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"Content\UserImages";

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

            if(ModelState.IsValid)
            {
                var company = Mapper.Map<CompanyViewModel, Company>(companyViewModel);

                response = _companyAppService.saveOrUpdate(company);
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        //[HttpPost]
        //[Route("company")]
        //public HttpResponseMessage AddLogo(int idUser)
        //{
        //    //if (!Request.Content.IsMimeMultipartContent("form-data"))
        //    //{
        //    //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    //}

        //    //var provider = new MultipartFormDataStreamProvider(workingFolder);

        //    //Request.Content.ReadAsMultipartAsync(provider);

        //    //return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpGet]
        //[Route("company")]
        //public HttpResponseMessage GetCompanyByUser(int id)
        //{
        //    var companyBLL = new CompanyBLL();

        //    var response = companyBLL.getCompanyByUser(id);

        //    return Request.CreateResponse(response.StatusCode, response);
        //}

        //[HttpGet]
        //[Route("company")]
        //public HttpResponseMessage GetOccupationArea()
        //{
        //    var occupationAreaBLL = new OccupationAreaBLL();

        //    var response = occupationAreaBLL.getListOccupationAreas();

        //    return Request.CreateResponse(response.StatusCode, response);
        //}
    }
}
