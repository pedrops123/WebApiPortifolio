using FluentValidation;
using Portifolio.Domain.Command.Commands.Request.Works.PatchThumbnail;

namespace Portifolio.Domain.Command.Handlers.Works.PatchThumbnail
{
    public sealed class PatchThumbnailWorkValidator : AbstractValidator<PatchThumbnailWorksRequest>
    {
        public PatchThumbnailWorkValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0).WithMessage("Id do projeto não pode ser 0 ou negativo.");
            RuleFor(r => r.img_thumbnail_id).GreaterThan(0).WithMessage("Id da imagem não pode ser 0 ou negativo.");
        }
    }
}
