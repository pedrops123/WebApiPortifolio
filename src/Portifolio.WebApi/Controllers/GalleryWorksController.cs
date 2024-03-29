﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Delete;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.PatchComment;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using System.Threading.Tasks;

namespace Portifolio.WebApi.Controllers
{
    [Route("api/v1/GalleryWorks")]
    [ApiController]
    public sealed class GalleryWorksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GalleryWorksController([FromServices] IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Listagem de fotos do trabalho
        /// </summary>
        /// <param name="request">Parametro de filtro </param>
        /// <returns>  </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FilterGalleryWorksResponse))]
        public async Task<IActionResult> GetList([FromQuery] FilterGalleryWorksRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        /// <summary>
        /// Upload de imagens no trabalho 
        /// </summary>
        /// <param name="id">Id do trabalho a ser vinculado</param>
        /// <param name="files">Arquivos</param>
        /// <returns> void </returns>
        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromRoute] int id, [FromForm] IFormFileCollection files)
        {
            var response = await _mediator.Send(new CreateGalleryWorksRequest(id, files));

            return Ok(response);
        }

        /// <summary>
        /// Deleta imagem do trabalho
        /// </summary>
        /// <param name="id">Id da imagem</param>
        /// <returns> void </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteGalleryWorksRequest(id));

            return Ok(response);
        }

        /// <summary>
        /// Atualiza descrição da imagem.
        /// </summary>
        /// <param name="request">Objeto de atualização</param>
        /// <param name="id">Id do registro </param>
        /// <returns> void </returns>
        [HttpPatch("PatchComment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PatchComment([FromBody] PatchGalleryWorksCommentRequest request, [FromRoute] int id)
        {
            request.Id = id;
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
