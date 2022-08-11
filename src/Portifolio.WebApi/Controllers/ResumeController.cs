using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.ITextSharp;
using System.Threading.Tasks;

namespace Portifolio.WebApi.Controllers
{
    [Route("api/v1/Resume")]
    public sealed class ResumeController : ControllerBase
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
        /// Rota de Criação do Curriculum
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResult))]
        public async Task<IActionResult> CreateResumeAsync()
        {
            var response = await _itextSharpUtils.CreateDocument();

            return File(response.FileBytes, response.ContentType, response.FileName);
        }
    }
}
