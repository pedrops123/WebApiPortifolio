using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Request.Works.Delete;
using Portifolio.Domain.Command.Commands.Request.Works.GetById;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Request.Works.PatchThumbnail;
using Portifolio.Domain.Command.Commands.Request.Works.Update;
using System.Threading.Tasks;

namespace WebApiPortifolio.Controllers
{
    [Route("api/v1/Works")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WorksController([FromServices] IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWorksRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] FilterWorksRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetByIdWorksRequest(id));

            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromRoute] int Id, [FromBody] UpdateWorksRequest request)
        {
            request.Id = Id;
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteWorksRequest(id));

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchThumbnail([FromRoute] int id, [FromBody] PatchThumbnailWorksRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}