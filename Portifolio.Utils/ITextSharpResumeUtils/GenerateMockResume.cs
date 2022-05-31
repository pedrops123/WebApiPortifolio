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

            var topics = PopulateTopicsResume();

            return new ResumeViewModel(parameters, topics);
        }

        private static List<TopicResume> PopulateTopicsResume()
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

            SubTopicResume st2 = new SubTopicResume(4, "DESENVOLVEDOR PLENO | GLOBALSYS | NOVEMBRO 2021 - ATUALMENTE", 1, true);

            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Criação de API’s REST conforme solicitação de US (User Story)."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Estudo de boas práticas (Clean Code) para ser aplicado no desenvolvimento do sistema."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Análise de regra de negócio."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Documentação do sistema desenvolvido."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Interação com equipe front end para adaptar o código desenvolvido."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 6, "Criação de pontos de entrada no projeto BFF (Back End for Front End)."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 7, "Utilização de Mensageria para envio de e-mails / notificações / Producer-Consumer(RabbitMQ)."));
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

            SubTopicResume st4 = new SubTopicResume(4, "DESENVOLVEDOR PLENO | LIBERTY SEGUROS | JANEIRO 2021 – MARÇO 2021", 3, true);

            st4.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 1, "Desenvolvimento de arquitetura Front-End Angular."));
            st4.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Criação de layout responsivo de acordo com protótipo."));
            st4.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Desenvolvimento de novas funcionalidades para o sistema."));
            st4.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Criação de WebApi’s RestFull."));
            st4.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Análise de regras e adaptação das mesmas ao sistema."));
            st4.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 6, "Desenvolvimento de rotas em API’s e validações backend. \n \n \n \n \n \n \n \n"));

            subTopicThird.Add(st4);

            SubTopicResume st5 = new SubTopicResume(4, "DESENVOLVEDOR PLENO | ELGIN S.A| SETEMBRO 2020 – DEZEMBRO 2020", 4, true);

            st5.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 1, "Levantamento de requisitos ao sistema."));
            st5.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Montagem de layout e desenvolvimento Front End Angular."));
            st5.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Desenvolvimento e manutenção de API’S REST .NET CORE."));
            st5.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Criação de tabelas necessárias ao sistema."));
            st5.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Documentação das atividades desenvolvidas."));
            st5.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 6, "Correção de bugs tanto API quanto Front End e estudo de boas práticas a serem incluídas no sistema."));

            subTopicThird.Add(st5);

            SubTopicResume st6 = new SubTopicResume(4, "DESENVOLVEDOR JR | TRAME & AUDIO PADRÃO | AGOSTO DE 2019 – SETEMBRO 2020", 5, true);

            st6.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Levantamento e análise de requisitos junto ao cliente interno."));
            st6.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Montagem do escopo de todo o sistema a ser desenvolvido."));
            st6.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Correção de bugs, inclusão de novas funcionalidades, estudo de novas tecnologias e inclusão das mesmas no sistema."));
            st6.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Criação de Tabelas e montagem de procedures."));
            st6.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Manutenção de Api’s RestFull e SOAP."));

            subTopicThird.Add(st6);


            SubTopicResume st7 = new SubTopicResume(4, "ESTAGIÁRIO/ANALISTA JR | GRUPO GPS | OUTUBRO DE 2016 - JULHO 2019", 6, true);

            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Levantamento e análise de requisitos junto ao cliente."));
            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Montagem do escopo de todo o sistema a ser desenvolvido."));
            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Desenvolver o sistema."));
            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Manutenção de Api’s RestFull e SOAP"));
            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Criação de Tabelas e montagem de procedures."));
            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 6, "Desenvolvimento de aplicações mobile."));

            subTopicThird.Add(st7);


            SubTopicResume st8 = new SubTopicResume(4, "ESTAGIÁRIO | PGOPEN| FEVEREIRO DE 2016 – ABRIL 2016", 7, true);

            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Manutenção de computadores."));
            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Gerenciamento de projetos de desenvolvimento."));
            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Ajuste de códigos Java."));
            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Suporte aos desenvolvedores"));
            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Desenvolvimento de manuais para usuário e ajudas gerais no setor de TI. \n \n \n"));

            subTopicThird.Add(st8);


            TopicResume thirdTopic = new TopicResume("Experiência", 3, subTopicThird);

            topics.Add(thirdTopic);

            List<SubTopicResume> subTopicsFourth = new List<SubTopicResume>();

            SubTopicResume ComplmentaryInformationsTechnicalCourse = new SubTopicResume(1, "Curso Técnico de Informática - People - 2015", 1, false);
            subTopicsFourth.Add(ComplmentaryInformationsTechnicalCourse);

            SubTopicResume ComplmentaryInformationsPosTechnicalCourse = new SubTopicResume(1, "Curso pós-técnico desenvolvedor multiplataforma (web & mobile) – Senai informática - 2016", 2, false);
            subTopicsFourth.Add(ComplmentaryInformationsPosTechnicalCourse);

            SubTopicResume ComplmentaryInformationsEnglishCourse = new SubTopicResume(1, "Inglês: Nível intermediário I - CNA - 2012", 3, false);
            subTopicsFourth.Add(ComplmentaryInformationsEnglishCourse);

            TopicResume FourthTopic = new TopicResume("Informações Complementares", 4, subTopicsFourth);

            topics.Add(FourthTopic);



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
