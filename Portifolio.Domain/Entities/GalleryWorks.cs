namespace Portifolio.Domain.Entities
{
    public class GalleryWorks : BaseEntity
    {
        public int IdProjeto { get; private set; }

        public string PathFile { get; private set; }

        public string Comment { get; private set; }

        public virtual Works Work { get; private set; }

        public GalleryWorks(
            int idProjeto,
            string pathFile)
        {
            IdProjeto = idProjeto;
            PathFile = pathFile;
        }

        private GalleryWorks()
        { }
    }
}
