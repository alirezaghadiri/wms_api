
using System.Web;
using System.Web.Http;
using WMS.DB;
using WMS.security;

namespace WMS.Controllers.api.v1
{
    public class configController : ApiController
    {
        [Route("v1/InitDatabase")]
        [HttpGet]
        public IHttpActionResult InitDatabase()
        {
           // var t = HttpContext.Current.User.Identity.Name;
             var dbcontext = new WMSDBContext();
            dbcontext.Database.Initialize(false);
            return Ok("عملیات با موفقیت انجام گردید");
        }
    }
}
