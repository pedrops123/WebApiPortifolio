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

        /// <summary>
        /// Rota de criação do curriculum
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreateResumeAsync()
        {
            var response =  await _itextSharpUtils.CreateDocument();

            return File(response.FileBytes, response.ContentType, response.FileName);
        }
    }
}
