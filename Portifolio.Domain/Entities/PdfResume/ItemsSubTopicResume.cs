namespace Portifolio.Domain.Entities.PdfResume
{
    public sealed class ItemsSubTopicResume : BaseEntity
    {
        public int SubTopicId { get; set; }
        public string Description { get; private set; }

        public ItemsSubTopicResume(
            int subTopicId,
            string description)
        {
            SubTopicId = subTopicId;
            Description = description;
        }

        private ItemsSubTopicResume()
        { }
    }
}
