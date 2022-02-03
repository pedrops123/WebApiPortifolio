using FluentValidation;
using Microsoft.AspNetCore.Http;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.GalleryWorks.Create
{
    public sealed class CreateGalleryWorksValidator : AbstractValidator<CreateGalleryWorksRequest>
    {
        public CreateGalleryWorksValidator()
        {
            RuleFor(r => r.IdProjeto).LessThanOrEqualTo(0)
                .WithMessage("Id do projeto nao pode ser 0 ou negativo.");

            RuleForEach(r => r.Files)
                .SetValidator(new FormFileValidator());
        }
    }


    public sealed class FormFileValidator : AbstractValidator<IFormFile>
    {
        public FormFileValidator()
        {
            RuleFor(r => r.FileName).Empty()
                .WithMessage("Nome do arquivo nao pode ser vazio !");

            RuleFor(r => r.ContentType).Empty()
              .WithMessage("Content Type nao pode ser vazio !");

            RuleFor(r => r.ContentType).NotEqual("image/jpg")
              .WithMessage("Arquivo precise ser uma imagem !");
        }
    }
}
