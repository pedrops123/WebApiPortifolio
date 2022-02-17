﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] int id, [FromForm] IEnumerable<IFormFile> files)
        {
            var response = await _mediator.Send(new CreateGalleryWorksRequest(id, files));

            return Ok(response);
        }
    }
}