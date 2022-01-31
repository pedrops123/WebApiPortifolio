using MediatR;
using Portifolio.Domain.Command.Commands.Response.Works.GetById;

namespace Portifolio.Domain.Command.Commands.Request.Works.GetById
{
    public class GetByIdWorksRequest : IRequest<GetByIdWorksResponse>
    {
        public int Id { get; set; }
    }
}
