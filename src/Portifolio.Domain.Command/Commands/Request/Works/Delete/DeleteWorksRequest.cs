using MediatR;

namespace Portifolio.Domain.Command.Commands.Request.Works.Delete
{
    public class DeleteWorksRequest : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteWorksRequest(int id)
        {
            Id = id;
        }
    }
}
