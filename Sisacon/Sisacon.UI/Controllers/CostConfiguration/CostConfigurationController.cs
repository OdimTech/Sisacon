using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers.CostConfiguration
{
    [RoutePrefix("api")]
    public class CostConfigurationController : ApiController
    {
        [HttpGet]
        [Route("costConfig")]
        public HttpResponseMessage GetConfigurationByUserId(int userId)
        {
            

            var response = costConfigBLL.getCostsConfigurationByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpPost]
        [Route("costConfig")]
        public HttpResponseMessage Save(Domain.CostConfiguration costConfig)
        {
            var costConfigBLL = new CostConfigurationBLL();
            var response = new ResponseMessage<Domain.CostConfiguration>();

            if (costConfig != null)
            {
                if (costConfig.Id == 0)
                {
                    response = costConfigBLL.save(costConfig);
                }
                else
                {
                    response = costConfigBLL.update(costConfig);
                }
            }

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
