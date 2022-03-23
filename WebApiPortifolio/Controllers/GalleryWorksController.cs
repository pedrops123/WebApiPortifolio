using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] FilterGalleryWorksRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post([FromRoute] int id, [FromForm] IEnumerable<IFormFile> files)
        {
            var response = await _mediator.Send(new CreateGalleryWorksRequest(id, files));

            return Ok(response);
        }
    }
}
