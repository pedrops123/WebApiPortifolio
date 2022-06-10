using System.Collections.Generic;

namespace Portifolio.Domain.Entities
{
    public class Works : BaseEntity
    {
        public string nome_projeto { get; private set; }

        public int? img_thumbnail_id { get; private set; }

        public string descritivo_capa { get; private set; }

        public string texto_projeto { get; private set; }

        public virtual IEnumerable<GalleryWorks> Fotos { get; private set; }

        public Works(
            string nomeProjeto,
            int? imgThumbnailId,
            string descritivoCapa,
            string textoProjeto)
        {
            nome_projeto = nomeProjeto;
            img_thumbnail_id = imgThumbnailId;
            descritivo_capa = descritivoCapa;
            texto_projeto = textoProjeto;
        }
    }
}