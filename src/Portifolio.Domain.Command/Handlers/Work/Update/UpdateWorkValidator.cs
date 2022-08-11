using FluentValidation;
using Portifolio.Domain.Command.Commands.Request.Works.Update;

namespace Portifolio.Domain.Command.Handlers.Work.Update
{
    public sealed class UpdateWorkValidator : AbstractValidator<UpdateWorksRequest>
    {
        public UpdateWorkValidator()
        {
            //RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.DescriptionCover).NotEmpty();
            RuleFor(r => r.ProjectName).NotEmpty();
            RuleFor(r => r.ProjectText).NotEmpty();
        }
    }
}
