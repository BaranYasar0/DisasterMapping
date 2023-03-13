using DisasterMapping.Api.Application.Features.Commands.Disasters.Create;
using DisasterMapping.Api.Application.Features.Dtos.Disaster;
using DisasterMapping.Api.Application.Features.Queries.Disasters.GetById;
using DisasterMapping.Api.Application.Features.Queries.Disasters.GetList;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetDisasterListQuery getDisasterList = new();
            List<GetDisasterListDto> result = await MediatR.Send(getDisasterList);
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetDisasterByIdQuery disasterQuery = new() { Id=id};
            GetDisasterByIdDto result = await MediatR.Send(disasterQuery);
            return Ok(result);
        }
    }
}
