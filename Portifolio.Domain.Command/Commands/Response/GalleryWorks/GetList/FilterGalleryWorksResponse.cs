using System;

namespace Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList
{
    public class FilterGalleryWorksResponse
    {
        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public string PathFile { get; set; }
        public string UrlFile { get; set; }
        public int UserInsert { get; set; }
        public string Comment { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
