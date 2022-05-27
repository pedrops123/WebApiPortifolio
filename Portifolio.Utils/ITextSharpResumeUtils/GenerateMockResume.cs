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

            List<SubTopicResume> subTopicFirst = new List<SubTopicResume>();

            subTopicFirst.Add(new SubTopicResume(1, "Desenvolvedor Web | Mobile", 1, false));

            TopicResume firstTopic = new TopicResume("Objetivo", 1, subTopicFirst);

            topics.Add(firstTopic);

            SubTopicResume st1 = new SubTopicResume(2, "GRADUAÇÃO | FACULDADE IMPACTA DE TECNOLOGIA | FEV DE 2017 - DEZ 2018", 1, true);

            st1.ItemsSubTopic.Add(new ItemsSubTopicResume(1, 1, "Curso Análise e Desenvolvimento de Sistemas"));

            List<SubTopicResume> subTopicSecond = new List<SubTopicResume>();

            subTopicSecond.Add(st1);

            TopicResume secondTopic = new TopicResume("Educação", 2, subTopicSecond);

            topics.Add(secondTopic);

            List<SubTopicResume> subTopicThird = new List<SubTopicResume>();

            SubTopicResume st2 = new SubTopicResume(3, "DESENVOLVEDOR PLENO | GLOBALSYS | NOVEMBRO 2021 - ATUALMENTE", 1, true);
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3,1, "Criação de API’s REST conforme solicitação de US (User Story)."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Estudo de boas práticas (Clean Code) para ser aplicado no desenvolvimento do sistema."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Análise de regra de negócio."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Documentação do sistema desenvolvido."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Interação com equipe front end para adaptar o código desenvolvido."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 6, "Criação de pontos de entrada no projeto BFF (Back End for Front End)."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 7 , "Utilização de Mensageria para envio de e-mails / notificações / Producer-Consumer(RabbitMQ)."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 8, "Correções de Bugs gerais."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 9, "Desenvolvimento de rotas em API’s e validações Backend."));

            subTopicThird.Add(st2);

            SubTopicResume st3 = new SubTopicResume(4, "DESENVOLVEDOR PLENO | EDENRED | ABRIL 2021 - NOVEMBRO 2021", 2, true);
            st3.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 1, "Atendimento de Chamados."));
            st3.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Atendimento ao Cliente"));
            st3.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Análise de erros referente ao portal Ticket."));
            st3.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Análise dos Códigos fontes."));
            st3.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Criação de procedures para geração de relatórios manuais."));

            subTopicThird.Add(st3);

            TopicResume thirdTopic = new TopicResume("Experiência", 3, subTopicThird);

            topics.Add(thirdTopic);

            //for (int quantity = 1; quantity <= number; quantity++)
            //{
            //    List<SubTopicResume> subTopics = new List<SubTopicResume>();

            //    for (int quantitySub = 1; quantitySub <= 5; quantitySub++)
            //    {
            //        SubTopicResume subTopic = new SubTopicResume(1, $"Sub Topico numero {quantity}" , true);

            //        for (int quantitySubItem = 1; quantitySubItem <= 6; quantitySubItem++)
            //        {
            //            ItemsSubTopicResume item = new ItemsSubTopicResume(1, $"item sub topic numero {quantitySubItem}");

            //            subTopic.ItemsSubTopic.Add(item);
            //        }
            //        subTopics.Add(subTopic);
            //    }

            //    TopicResume topic = new TopicResume($"Topico numero {quantity}", subTopics);

            //    topics.Add(topic);
            //}

            return topics;
        }

        private static List<GeneralParameters> PopulateGeneralParameters(List<GeneralParameters> parameters)
        {
            parameters.Add(new GeneralParameters((ResumeParameters.MartialStatus).ToString(), "Casado"));
            parameters.Add(new GeneralParameters((ResumeParameters.Address).ToString(), "Rua José Celestino Saad, nº 245, Jd Isis, Cotia/SP"));
            parameters.Add(new GeneralParameters((ResumeParameters.CellPhone).ToString(), "(11) 99708-3252"));
            parameters.Add(new GeneralParameters((ResumeParameters.Email).ToString(), "pedro.furlan1304@hotmail.com"));
            parameters.Add(new GeneralParameters((ResumeParameters.GitHubLink).ToString(), "https://github.com/pedrops123/pedrops123"));
            parameters.Add(new GeneralParameters((ResumeParameters.LinkedinLink).ToString(), "\n https://www.linkedin.com/in/pedro-vin%C3%ADcius-rodrigues-furlan-a691bb10a/"));

            return parameters;
        }
    }
}
