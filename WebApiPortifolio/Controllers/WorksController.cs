using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Response.Works.Create;
using System.Threading.Tasks;

namespace WebApiPortifolio.Controllers
{
    [Route("api/v1/Works")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        [HttpPost]
        public async Task<CreateWorkResponse> Post( [FromBody] CreateWorkRequest request, [FromServices] IMediator mediator)
            => await mediator.Send(request);
        
    }
}
