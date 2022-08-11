using System.Collections.Generic;

namespace Portifolio.Domain.Entities
{
    public class Works : BaseEntity
    {
        public string ProjectName { get; private set; }

        public int? ImgThumbnailId { get; private set; }

        public string DescriptionCover { get; private set; }

        public string ProjectText { get; private set; }

        public virtual IEnumerable<GalleryWorks> Photos { get; private set; }

        public Works(
            string projectName,
            int? imgThumbnailId,
            string descriptionCover,
            string projectText)
        {
            ProjectName = projectName;
            ImgThumbnailId = imgThumbnailId;
            DescriptionCover = descriptionCover;
            ProjectText = projectText;
        }

        private Works()
        { }
    }
}