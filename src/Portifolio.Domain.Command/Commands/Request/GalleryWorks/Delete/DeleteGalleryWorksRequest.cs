using MediatR;

namespace Portifolio.Domain.Command.Commands.Request.GalleryWorks.Delete
{
    public sealed class DeleteGalleryWorksRequest : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteGalleryWorksRequest(int id)
        {
            Id = id;
        }
    }
}
