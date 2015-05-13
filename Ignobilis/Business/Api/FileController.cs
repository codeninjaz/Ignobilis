using System.Web.Http;

namespace Ignobilis.Business.Api
{
    public class FileController : ApiController
    {
        [Route("api/jesus")]
        public string GetAFuckingString()
        {
            return "JESUS";
        }
    }
}
