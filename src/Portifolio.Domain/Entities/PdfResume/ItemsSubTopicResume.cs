namespace Portifolio.Domain.Entities.PdfResume
{
    public sealed class ItemsSubTopicResume : BaseEntity
    {
        public int SubTopicId { get; set; }
        public string Description { get; private set; }
        public int Order { get; private set; }

        public ItemsSubTopicResume(
            int subTopicId,
            int order,
            string description)
        {
            SubTopicId = subTopicId;
            Order = order;
            Description = description;
        }

        private ItemsSubTopicResume()
        { }
    }
}
