﻿namespace Portifolio.Domain.Entities
{
    public class GalleryWorks : BaseEntity
    {
        public int ProjectId { get; private set; }

        public string PathFile { get; private set; }

        public string Comment { get; private set; }

        public virtual Works Work { get; private set; }

        public GalleryWorks(
            int projectId,
            string pathFile)
        {
            ProjectId = projectId;
            PathFile = pathFile;
        }

        private GalleryWorks()
        { }
    }
}
