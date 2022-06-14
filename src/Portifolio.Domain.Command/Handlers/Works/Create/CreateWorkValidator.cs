using FluentValidation;
using Portifolio.Domain.Command.Commands.Request.Works.Create;

namespace Portifolio.Domain.Command.Handlers.Works.Create
{
    public sealed class CreateWorkValidator : AbstractValidator<CreateWorksRequest>
    {
        public CreateWorkValidator()
        {
            RuleFor(r => r.descritivo_capa).NotEmpty();
            RuleFor(r => r.nome_projeto).NotEmpty();
            RuleFor(r => r.texto_projeto).NotEmpty();
        }
    }
}
