using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using System;

namespace Portifolio.Domain.Command.Commands.Response.Works.GetList
{
    public sealed class FilterWorksResponse
    {
        public int Id { get; set; }

        public string nome_projeto { get;  set; }

        public int? img_thumbnail_id { get; set; }

        public string descritivo_capa { get;  set; }

        public string texto_projeto { get;  set; }

        public int UserInsert { get;  set; }

        public DateTime InsertDate { get;  set; }

        public int? UserUpdate { get;  set; }

        public DateTime? UpdateDate { get;  set; }

        public FilterGalleryWorksResponse img_thumbnail { get; set; }

        public FilterWorksResponse()
        {
            this.img_thumbnail = new FilterGalleryWorksResponse();
        }
    }
}
