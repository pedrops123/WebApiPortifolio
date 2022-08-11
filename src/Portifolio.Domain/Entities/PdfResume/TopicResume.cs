using System.Collections.Generic;

namespace Portifolio.Domain.Entities.PdfResume
{
    public class TopicResume : BaseEntity
    {
        public string Description { get; private set; }
        public int Order { get; private set; }
        public virtual IEnumerable<SubTopicResume> SubTopics { get; private set; }

        public TopicResume(string description)
        {
            Description = description;
        }

        public TopicResume(
            string description,
            int order,
            List<SubTopicResume> subTopics)
        {
            Description = description;
            Order = order;
            SubTopics = subTopics;
        }

        private TopicResume()
        { }
    }
}
