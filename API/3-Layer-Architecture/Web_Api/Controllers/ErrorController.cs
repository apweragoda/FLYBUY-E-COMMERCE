using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Web_Api.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var statusCode = exception.Error.GetType().Name switch
            {
                "ArgumentException" => HttpStatusCode.BadRequest,
                "NullReferenceException" => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.ServiceUnavailable
            };

            logger.LogError(exception.Error, $"Some Error occured : {exception.Error.Message}");
            return Problem(detail: exception.Error.Message, statusCode: (int) statusCode);
        }
    }
}
