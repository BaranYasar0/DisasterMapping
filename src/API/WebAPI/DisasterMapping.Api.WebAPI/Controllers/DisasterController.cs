using DisasterMapping.Api.Application.Features.Commands.Disasters.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterMapping.Api.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisasterController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDisasterCommand createDisasterCommand)
        {
            return Ok(await MediatR.Send(createDisasterCommand));
        }
    }
}
