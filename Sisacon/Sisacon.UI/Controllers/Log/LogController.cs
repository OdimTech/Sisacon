using Sisacon.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers.Log
{
    [RoutePrefix("api")]
    public class LogController : ApiController
    {
        private readonly ILogAppService _logAppService;

        public LogController(ILogAppService logAppService)
        {
            _logAppService = logAppService;
        }

        [HttpGet]
        [Route("log")]
        public HttpResponseMessage getLogs()
        {
            var response = _logAppService.getLogs();

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("log")]
        public HttpResponseMessage getLogById(int id)
        {
            var response = _logAppService.getLogById(id);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
