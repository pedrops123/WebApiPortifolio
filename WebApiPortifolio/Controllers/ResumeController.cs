using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.ITextSharp;
using System.Threading.Tasks;

namespace WebApiPortifolio.Controllers
{
    [Route("api/v1/Resume")]
    public class ResumeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITextSharpUtils _itextSharpUtils;

        public ResumeController([FromServices] IMediator mediator, 
            ITextSharpUtils itextSharpUtils)
        {
            _mediator = mediator;
            _itextSharpUtils = itextSharpUtils;
        }

        [HttpGet]
        public async Task<IActionResult> CreateResumeAsync()
        {
            var response = _itextSharpUtils.CreateDocument();

            return Ok(response);
        }

    }
}
