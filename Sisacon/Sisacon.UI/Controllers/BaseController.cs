using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    public class BaseController : ApiController
    {
        private string _ApplicationPath;

        public string ApplicationPath
        {
            get { return System.Web.Hosting.HostingEnvironment.MapPath("~/Content/UserImages/"); }
        }

    }
}
