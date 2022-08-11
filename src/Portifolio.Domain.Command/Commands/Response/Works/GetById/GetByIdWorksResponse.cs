using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using System;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Commands.Response.Works.GetById
{
    public class GetByIdWorksResponse
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

        public virtual List<FilterGalleryWorksResponse> Photos { get; set; }

        public FilterGalleryWorksResponse img_thumbnail { get; set; }

        public GetByIdWorksResponse() => this.img_thumbnail = new FilterGalleryWorksResponse();
    }
}
