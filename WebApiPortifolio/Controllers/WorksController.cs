using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Request.Works.Delete;
using Portifolio.Domain.Command.Commands.Request.Works.GetById;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Request.Works.Update;
using Portifolio.Domain.Command.Commands.Response.Works.GetById;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using System.Collections.Generic;
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
        public async Task<Unit> Post([FromBody] CreateWorkRequest request)
            => await _mediator.Send(request);

        [HttpGet]
        public async Task<List<FilterWorksResponse>> GetList([FromQuery] FilterWorksRequest request)
            => await _mediator.Send(request);

        [HttpGet("GetById")]
        public async Task<GetByIdWorksResponse> GetById([FromQuery] GetByIdWorksRequest request) =>
            await _mediator.Send(request);

        [HttpPut("{Id}")]
        public async Task<Unit> Put([FromRoute] int Id, [FromBody] UpdateWorkRequest request)
        {
            request.Id = Id;
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromQuery] DeleteWorksRequest request) 
            => await _mediator.Send(request);
    }
}
