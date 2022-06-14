using System.Collections.Generic;

namespace Portifolio.Domain.Entities.PdfResume
{
    public class SubTopicResume : BaseEntity
    {
        public int TopicId { get; set; }
        public string Description { get; private set; }
        public bool IsBold { get; private set; }
        public int Order { get; private set; }
        public virtual List<ItemsSubTopicResume> ItemsSubTopic { get; set; } = new List<ItemsSubTopicResume>();

        public SubTopicResume(
            int topicId,
            string description,
            int order,
            bool isBold)
        {
            TopicId = topicId;
            Description = description;
            Order = order;
            IsBold = isBold;
        }

        private SubTopicResume()
        { }
    }
}
