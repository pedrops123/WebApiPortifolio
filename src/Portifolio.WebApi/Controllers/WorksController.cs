﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Request.Works.Delete;
using Portifolio.Domain.Command.Commands.Request.Works.GetById;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Request.Works.PatchThumbnail;
using Portifolio.Domain.Command.Commands.Request.Works.Update;
using Portifolio.Domain.Command.Commands.Response.Works.GetById;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using System.Threading.Tasks;

namespace Portifolio.WebApi.Controllers
{
    [Route("api/v1/Works")]
    [ApiController]
    public sealed class WorksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorksController([FromServices] IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastro do trabalho
        /// </summary>
        /// <param name="request">Parametro cadastro de trabalho</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateWorksRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        /// <summary>
        /// Listagem dos trabalhos
        /// </summary>
        /// <param name="request">Filtro de listagem</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FilterWorksResponse))]
        public async Task<IActionResult> GetList([FromQuery] FilterWorksRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        /// <summary>
        /// Coleta trabalho por Id do registro
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByIdWorksResponse))]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetByIdWorksRequest(id));

            return Ok(response);
        }

        /// <summary>
        /// Atualização do trabalho.
        /// </summary>
        /// <param name="Id">Id do registro</param>
        /// <param name="request">Parametros de atualização</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateWorksRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        /// <summary>
        /// Deleta trabalho
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteWorksRequest(id));

            return Ok(response);
        }

        /// <summary>
        /// Atualiza imagem inicial do trabalho a ser mostrado.
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <param name="request">Id da imagem vinculado</param>
        /// <returns></returns>
        [HttpPatch("PatchThumnail/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PatchThumbnail([FromRoute] int id, [FromBody] PatchThumbnailWorksRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}