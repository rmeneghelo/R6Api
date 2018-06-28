using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using R6Api.Application.Queries;
using System.Threading.Tasks;

namespace R6Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserStatisticsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediatr;

        public UserStatisticsController(ILoggerFactory logger, IMediator mediatr)
        {
            _logger = logger.CreateLogger<UserStatisticsController>();
            _mediatr = mediatr;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserStatisticsQuery command)
        {
            var result = await _mediatr.Send(command).ConfigureAwait(false);

            if(result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}