namespace Portifolio.Domain.Query.Mappers.Works
{
    public sealed class WorksJoinMap
    {
        private readonly Entities.GalleryWorks _thumb;
        public WorksJoinMap(Entities.GalleryWorks thumb)
        {
            _thumb = thumb;
        }

        public Entities.Works Map(Entities.Works works)
        {
            works.setThumbnail(_thumb);

            return works;
        }
    }
}
