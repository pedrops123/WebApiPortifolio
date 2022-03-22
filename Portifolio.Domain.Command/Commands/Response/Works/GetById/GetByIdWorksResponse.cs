using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using Portifolio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Commands.Response.Works.GetById
{
    public class GetByIdWorksResponse
    {
        public int Id { get; set; }

        public string nome_projeto { get; set; }

        public string img_thumbnail { get; set; }

        public string descritivo_capa { get; set; }

        public string texto_projeto { get; set; }

        public int UserInsert { get; set; }

        public DateTime InsertDate { get; set; }

        public int? UserUpdate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual List<FilterGalleryWorksResponse> Fotos { get; set; }
    }
}
