using FluentValidation;
using Portifolio.Domain.Command.Commands.Request.Works.Create;

namespace Portifolio.Domain.Command.Handlers.Works.Create
{
    public class CreateWorkValidator :AbstractValidator<CreateWorksRequest>
    {
        public CreateWorkValidator()
        {
            RuleFor(r => r.texto_projeto).NotEmpty().WithMessage("Texto do projeto não pode ser Vazio !");
        }
    }
}
