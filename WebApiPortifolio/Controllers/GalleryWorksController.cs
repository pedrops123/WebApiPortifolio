using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using System.Threading.Tasks;

namespace WebApiPortifolio.Controllers
{
    [Route("api/v1/GalleryWorks")]
    [ApiController]
    public class GalleryWorksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GalleryWorksController([FromServices] IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Unit> Post([FromQuery] CreateGalleryWorksRequest request)
            => await _mediator.Send(request);


    }
}
