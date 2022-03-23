namespace Portifolio.Domain.Query.Repositories.Works.Filters
{
    public sealed class FilterWorksRequest
    {
        public string nome_projeto { get; set; }

        public string descritivo_capa { get; set; }

        public string texto_projeto { get; set; }
    }
}
