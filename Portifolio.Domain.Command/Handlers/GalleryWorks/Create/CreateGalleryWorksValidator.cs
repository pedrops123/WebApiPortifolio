using FluentValidation;
using Microsoft.AspNetCore.Http;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;

namespace Portifolio.Domain.Command.Handlers.GalleryWorks.Create
{
    public sealed class CreateGalleryWorksValidator : AbstractValidator<CreateGalleryWorksRequest>
    {
        public CreateGalleryWorksValidator()
        {
            RuleFor(r => r.IdProjeto).GreaterThan(0)
                .WithMessage("Id do projeto nao pode ser 0 ou negativo.");

            RuleForEach(r => r.Files)
                .SetValidator(new FormFileValidator());
        }
    }

    public sealed class FormFileValidator : AbstractValidator<IFormFile>
    {
        private const string _contentTypePng = "image/png";
        private const string _contentTypejpeg = "image/jpeg";

        public FormFileValidator()
        {
            RuleFor(r => r.FileName).NotEmpty()
                .WithMessage("Nome do arquivo nao pode ser vazio !");

            RuleFor(r => r.ContentType).NotEmpty()
              .WithMessage("Content Type nao pode ser vazio !");

            RuleFor(r => r.ContentType).Custom((content, context) =>
            {
                if (content.Trim() != _contentTypePng &&
                    content.Trim() != _contentTypejpeg)
                {
                    context.AddFailure("Somente arquivos nos formatos .png ou .jpeg.");
                }
            });
        }
    }
}
