using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Ping() 
        {
            _logger.LogInformation("Ping !!!!");
            return "Ping";
        }
    }
}
