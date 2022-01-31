using FluentValidation;
using Portifolio.Domain.Command.Commands.Request.Works.Create;

namespace Portifolio.Domain.Command.Handlers.Works.Create
{
    public class CreateWorkValidator :AbstractValidator<CreateWorkRequest>
    {
        public CreateWorkValidator()
        {
            RuleFor(r => r.texto_projeto).NotEmpty().WithMessage("Texto do projeto não pode ser Vazio !");
            RuleFor(r => r.img_thumbnail).NotEmpty().WithMessage($"{ typeof(CreateWorkRequest).GetProperty("img_thumbnail").Name } não pode ser Vazio !");
        }
    }
}
