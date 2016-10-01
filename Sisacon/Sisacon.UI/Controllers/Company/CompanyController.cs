using Sisacon.BLL;
using Sisacon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class CompanyController : ApiController
    {
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"Content\UserImages";

        [HttpPost]
        [Route("company")]
        public HttpResponseMessage Save(Company company)
        {
            var response = new ResponseMessage<Company>();
            var companyBLL = new CompanyBLL();

            if (company != null)
            {
                HttpRequestMessage request = this.Request;
                if (!request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);

                var task = request.Content.ReadAsMultipartAsync(provider).
                    ContinueWith<HttpResponseMessage>(o =>
                    {

                        return new HttpResponseMessage()
                        {
                            Content = new StringContent("File uploaded.")
                        };
                    }
                );

                if (company.Id == 0)
                {
                    response = companyBLL.save(company);
                }
                else
                {
                    response = companyBLL.update(company);
                }
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpPost]
        [Route("company")]
        public HttpResponseMessage AddLogo(int idUser)
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var provider = new MultipartFormDataStreamProvider(workingFolder);

            Request.Content.ReadAsMultipartAsync(provider);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("company")]
        public HttpResponseMessage GetCompanyByUser(int id)
        {
            var companyBLL = new CompanyBLL();

            var response = companyBLL.getCompanyByUser(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("company")]
        public HttpResponseMessage GetOccupationArea()
        {
            var occupationAreaBLL = new OccupationAreaBLL();

            var response = occupationAreaBLL.getListOccupationAreas();

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
