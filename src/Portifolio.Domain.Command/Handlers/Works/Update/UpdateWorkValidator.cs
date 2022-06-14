using FluentValidation;
using Portifolio.Domain.Command.Commands.Request.Works.Update;

namespace Portifolio.Domain.Command.Handlers.Works.Update
{
    public sealed class UpdateWorkValidator : AbstractValidator<UpdateWorksRequest>
    {
        public UpdateWorkValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.descritivo_capa).NotEmpty();
            RuleFor(r => r.nome_projeto).NotEmpty();
            RuleFor(r => r.texto_projeto).NotEmpty();
        }
    }
}
