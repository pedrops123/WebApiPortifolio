using System.Collections.Generic;

namespace Portifolio.Domain.Entities.PdfResume
{
    public class SubTopicResume : BaseEntity
    {
        public int TopicId { get; set; }
        public string Description { get; private set; }

        public List<ItemsSubTopicResume> ItemsSubTopic { get; set; } = new List<ItemsSubTopicResume>();

        public SubTopicResume(
            int topicId,
            string description)
        {
            TopicId = topicId;
            Description = description;
        }

        private SubTopicResume()
        { }
    }
}
