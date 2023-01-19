using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using System;

namespace Portifolio.Domain.Command.Commands.Response.Works.GetList
{
    public sealed class FilterWorksResponse
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public int? ImgThumbnailId { get; set; }

        public string DescriptionCover { get; set; }

        public string ProjectText { get; set; }

        public int UserInsert { get; set; }

        public DateTime InsertDate { get; set; }

        public int? UserUpdate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public FilterGalleryWorksResponse img_thumbnail { get; set; } = null;

    }
}
