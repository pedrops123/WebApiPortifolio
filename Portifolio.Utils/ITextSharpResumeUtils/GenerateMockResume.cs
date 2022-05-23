using Portifolio.Domain.Entities;
using Portifolio.Domain.Entities.PdfResume;
using Portifolio.Domain.Enums;
using Portifolio.Domain.ViewModels;
using System.Collections.Generic;

namespace Portifolio.Utils.ITextSharpResumeUtils
{
    public static class GenerateMockResume
    {

        public static ResumeViewModel Generate()
        {
            List<GeneralParameters> parameters = new List<GeneralParameters>();

            PopulateGeneralParameters(parameters);

            var topics = PopulateTopicsResume(10);

            return new ResumeViewModel(parameters, topics);
        }

        private static List<TopicResume> PopulateTopicsResume(int number)
        {
            List<TopicResume> topics = new List<TopicResume>();

            for (int quantity = 1; quantity <= number; quantity++)
            {
                List<SubTopicResume> subTopics = new List<SubTopicResume>();

                for (int quantitySub = 1; quantitySub <= 5; quantitySub++)
                {
                    SubTopicResume subTopic = new SubTopicResume(1, $"Sub Topico numero {quantity}");

                    for (int quantitySubItem = 1; quantitySubItem <= 6; quantitySubItem++)
                    {
                        ItemsSubTopicResume item = new ItemsSubTopicResume(1, $"item sub topic numero {quantitySubItem}");

                        subTopic.ItemsSubTopic.Add(item);
                    }
                    subTopics.Add(subTopic);
                }

                TopicResume topic = new TopicResume($"Topico numero {quantity}", subTopics);

                topics.Add(topic);
            }

            return topics;
        }

        private static List<GeneralParameters> PopulateGeneralParameters(List<GeneralParameters> parameters)
        {
            parameters.Add(new GeneralParameters((ResumeParameters.MartialStatus).ToString(), "Casado"));
            parameters.Add(new GeneralParameters((ResumeParameters.Address).ToString(), "Rua José Celestino Saad, nº 245, Jd Isis, Cotia/SP"));
            parameters.Add(new GeneralParameters((ResumeParameters.CellPhone).ToString(), "(11) 99708-3252"));
            parameters.Add(new GeneralParameters((ResumeParameters.Email).ToString(), "pedro.furlan1304@hotmail.com"));
            parameters.Add(new GeneralParameters((ResumeParameters.GitHubLink).ToString(), "https://github.com/pedrops123/pedrops123"));
            parameters.Add(new GeneralParameters((ResumeParameters.LinkedinLink).ToString(), "https://www.linkedin.com/in/pedro-vin%C3%ADcius-rodrigues-furlan-a691bb10a/"));

            return parameters;
        }
    }
}
