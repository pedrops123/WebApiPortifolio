using FluentValidation;
using Portifolio.Domain.Command.Commands.Request.Works.Create;

namespace Portifolio.Domain.Command.Handlers.Work.Create
{
    public sealed class CreateWorkValidator : AbstractValidator<CreateWorksRequest>
    {
        public CreateWorkValidator()
        {
            RuleFor(r => r.DescriptionCover).NotEmpty();
            RuleFor(r => r.ProjectName).NotEmpty();
            RuleFor(r => r.ProjectText).NotEmpty();
        }
    }
}
