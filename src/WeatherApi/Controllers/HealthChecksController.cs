using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthChecksController : ControllerBase
    {
        [HttpGet("readiness")]
        public ActionResult GetReadiness()
        {
            return new OkResult();
        }

        [HttpGet("liveness")]
        public ActionResult GetLiveness()
        {
            return new OkResult();
        }

        [HttpGet("startup")]
        public ActionResult GetStartup()
        {
            return new OkResult();
        }
    }
}