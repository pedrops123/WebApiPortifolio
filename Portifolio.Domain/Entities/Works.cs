namespace Portifolio.Domain.Entities
{
    public sealed class Works : BaseEntity
    {
        public string nome_projeto { get; private set; }
        public string img_thumbnail { get; private set; }
        public string descritivo_capa { get; private set; }
        public string texto_projeto { get; private set; }
    }
}