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

            IEnumerable<string> listOfTopicsTechnologies = new List<string>() { "FRONT END", "BACK END", "BANCO DE DADOS", "MOBILE", "API'S" , "Design de Soluções (Solution Design)" };

            IEnumerable<string[]> listOfKnowlegesTechnologies = new List<string[]>()
            {
                new string[]{ "HTML 5" , "C# / ASP.NET" , "Microsoft SQL", "Android (Kotlin)" , "RestFull" ,"Lucid Chart" },
                new string[]{ "CSS 3" , ".NET CORE", "Mongo DB", "Flutter (Iniciante)" , "SOAP" , "Draw.io" },
                new string[]{ "Bootstrap 4" , "Java" , "Fire Base", "" , "" ,""},
                new string[]{ "Java Script" , "Python" , "MySql", "" , "", ""},
                new string[]{ "Type Script" , "Visual Basic" , "", "" , "","" },
                new string[]{ "CSS Grid Layout" , "PHP" , "", "" , "" , "" },
                new string[]{ "CSS Flex Box" , "Docker" , "", "" , "" , "" },
                new string[]{ "" , "Node JS", "", "" , ""  ,""},
            };

            IEnumerable<string> listOfTopicsFrameworks = new List<string>() { "C#/.NET", "FRONT END", "NODE JS" };

            IEnumerable<string[]> listOfKnowlegesFrameworks = new List<string[]>()
            {
                new string[]{ "IText Sharp" , "JQuery" , "Express"},
                new string[]{ "SharpZipLib" , "Angular" , ""},
                new string[]{ "Dapper" , "Vue.js" , ""},
                new string[]{ "Entity Framework" , "" , ""},
                new string[]{ "XPagedList" , "" , ""},
                new string[]{ "Selenium" , "" , ""},
                new string[]{ "Fluent Validation" , "" , ""},
                new string[]{ "Auto Mapper" , "" , ""},
                new string[]{ "Mediator (MediatR)" , "" , ""}
            };

            return new ResumeViewModel(parameters, topics, listOfTopicsTechnologies, listOfKnowlegesTechnologies, listOfTopicsFrameworks, listOfKnowlegesFrameworks);
        }

        private static List<TopicResume> PopulateTopicsResume()
        {
            List<TopicResume> topics = new List<TopicResume>();

            List<SubTopicResume> subTopicFirst = new List<SubTopicResume>();

            subTopicFirst.Add(new SubTopicResume(1, "Desenvolvedor Web", 1, false));

            subTopicFirst.Add(new SubTopicResume(1, "Arquiteto de Soluções", 2, false));

            TopicResume firstTopic = new TopicResume("Objetivo", 1, subTopicFirst);

            topics.Add(firstTopic);

            SubTopicResume stpos = new SubTopicResume(2, "MBA | FACULDADE IMPACTA DE TECNOLOGIA | ABRIL DE 2024 - DEZEMBRO 2025", 1, true);

            stpos.ItemsSubTopic.Add(new ItemsSubTopicResume(1, 1, "Arquitetura de Soluções"));

            SubTopicResume stgrad = new SubTopicResume(2, "GRADUAÇÃO | FACULDADE IMPACTA DE TECNOLOGIA | FEV DE 2017 - DEZ 2018", 1, true);

            stgrad.ItemsSubTopic.Add(new ItemsSubTopicResume(1, 1, "Análise e Desenvolvimento de Sistemas"));

            List<SubTopicResume> subTopicSecond = new List<SubTopicResume>();

            subTopicSecond.Add(stpos);
            subTopicSecond.Add(stgrad);

            TopicResume secondTopic = new TopicResume("Educação", 2, subTopicSecond);

            topics.Add(secondTopic);

            List<SubTopicResume> subTopicThird = new List<SubTopicResume>();

            SubTopicResume stUnicaProteo = new SubTopicResume(4, "DESENVOLVEDOR PLENO .NET | TECNOLOGIA ÚNICA | JANEIRO 2025 - MARÇO 2026 (Projeto : Proteo - Tecnologia para Seguros)", 1, true);

            stUnicaProteo.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Desenvolvimento de Web APIs: Criação de APIs modulares em .NET/C# voltadas para o setor de seguros, seguindo o padrão BFF (Backend for Frontend) para integração de fluxos."));
            stUnicaProteo.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Integração InsureMO: Implementação de regras de negócio e fluxos sistêmicos integrados à plataforma InsureMO, visando agilidade no processamento de seguros."));
            stUnicaProteo.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Arquitetura de Dados: Atuação em modelo database-per-service com SQL Server, sendo responsável pela criação de tabelas, scripts, Stored Procedures e versionamento de banco de dados por API."));
            stUnicaProteo.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Lógica de Orquestração: Utilização de Step Functions no desenvolvimento de rotinas e processos assíncronos dentro da aplicação."));
            stUnicaProteo.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Consumo de Persistência: Implementação de acesso a dados de alta performance utilizando o micro-ORM PetaPoco."));
            stUnicaProteo.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Ciclo de Entrega: Utilização de esteiras de CI/CD no Azure Pipelines para publicação e deploy das aplicações."));

            subTopicThird.Add(stUnicaProteo);

            SubTopicResume stUnicaParceria = new SubTopicResume(4, "DESENVOLVEDOR PLENO .NET | TECNOLOGIA ÚNICA | MAIO 2023 - JANEIRO 2025   (Projeto : Parceria Premiada)", 1, true);

            stUnicaParceria.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Revitalização de Sistema Legado: Liderança técnica na reativação e modernização de um sistema monolítico (Parceria Premiada) voltado para incentivos e bonificações no setor de agronegócio."));
            stUnicaParceria.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Refatoração e Regras de Negócio: Revisão integral de fluxos e módulos funcionais, atualizando regras de negócio obsoletas para garantir a conformidade com as operações atuais da empresa."));
            stUnicaParceria.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Desenvolvimento Full Stack: Manutenção e criação de novos fluxos utilizando .NET/C# com o micro-ORM PetaPoco no backend, e Razor com JavaScript para interfaces dinâmicas."));
            stUnicaParceria.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Persistência de Dados: Modelagem de tabelas e desenvolvimento de Stored Procedures em SQL Server, otimizando a manipulação e o consumo de dados do sistema."));
            stUnicaParceria.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Gestão de Código Compartilhado: Atuação em ambiente de monolito compartilhado, gerenciando a coexistência de múltiplos projetos e campanhas dentro da mesma estrutura de código."));

            subTopicThird.Add(stUnicaParceria);

            SubTopicResume st2 = new SubTopicResume(4, "DESENVOLVEDOR PLENO .NET | GLOBALSYS | NOVEMBRO 2021 - JUNHO 2023", 1, true);

            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Arquitetura de Microserviços e BFF: Desenvolvimento de sistemas para terceirização de frotas e seguros baseados em APIs RESTful modulares, utilizando o padrão BFF (Backend for Frontend) para orquestração de chamadas."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Padrões de Projeto e Performance: Implementação de CQRS para separação de leitura e escrita, otimizando a performance com Entity Framework na camada de persistência e Dapper para consultas de alta velocidade."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Mensageria e Eventos: Arquitetura orientada a eventos utilizando RabbitMQ (modelo Producer-Consumer) para garantir o processamento assíncrono e o desacoplamento dos módulos."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Qualidade e Validação: Utilização de Fluent Validation para consistência de dados e Migrations para evolução estruturada do banco de dados."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "DevOps e Documentação: Integração de esteiras de CI/CD via Azure Pipelines e documentação técnica de Web Services através do Swagger."));
            st2.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Processamento de Dados (ETL): Desenvolvimento de um projeto especializado em ETL para automação e carga de dados em larga escala para clientes externos."));


            subTopicThird.Add(st2);

            SubTopicResume st3 = new SubTopicResume(4, "ANALISTA DE SUPORTE / DESENVOLVEDOR PLENO | EDENRED  (Ticket Log / Benefícios) | ABRIL 2021 - NOVEMBRO 2021", 2, true);

            st3.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 1, "Sustentação de Sistemas: Responsável pela manutenção corretiva e suporte ao código-fonte legado do sistema de benefícios, garantindo a estabilidade da operação."));
            st3.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 2, "Resolução de Incidentes: Análise e correção de bugs críticos reportados pelos clientes, atuando diretamente na investigação de causa raiz no código."));
            st3.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 3, "Gestão de Regras de Negócio: Execução de processos operacionais sensíveis, como a liberação e o bloqueio de benefícios, seguindo rigorosos critérios de segurança."));
            st3.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 4, "Documentação Técnica: Mapeamento e documentação de fluxos de sistema, Stored Procedures e regras de negócio para preservação do conhecimento técnico da plataforma."));


            subTopicThird.Add(st3);

            SubTopicResume st4 = new SubTopicResume(4, "DESENVOLVEDOR PLENO FULL STACK | LIBERTY SEGUROS | JANEIRO 2021 – MARÇO 2021", 3, true);

            st4.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 1, "Desenvolvimento Front-end: Atuação no desenvolvimento e manutenção de interfaces para o portal de cotação de seguros, utilizando Angular para criar uma experiência de usuário fluida e responsiva."));
            st4.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 2, "Transição para Full Stack: Devido à rápida adaptação técnica, passei a auxiliar no desenvolvimento do Back-end, colaborando na integração de APIs e lógica de negócio do sistema de cotações."));
            st4.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 3, "Setor de Seguros: Experiência com regras de negócio complexas voltadas para cálculos de prêmios e propostas de seguros."));

            subTopicThird.Add(st4);

            SubTopicResume st5 = new SubTopicResume(4, "DESENVOLVEDOR PLENO .NET | ELGIN S.A| SETEMBRO 2020 – DEZEMBRO 2020", 4, true);

            st5.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 1, "Desenvolvimento Web: Atuação no front-end e back-end do portal de atendimento da empresa, utilizando Angular para interfaces dinâmicas e .NET para a lógica de negócio."));
            st5.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 2, "Web Services: Desenvolvimento e manutenção de Web Services (APIs), garantindo a integração eficiente entre o portal e os sistemas internos."));
            st5.ItemsSubTopic.Add(new ItemsSubTopicResume(4, 3, "Sustentação de Sistemas: Apoio técnico na evolução de funcionalidades e correção de bugs no ecossistema de atendimento ao cliente."));

            subTopicThird.Add(st5);

            SubTopicResume st6 = new SubTopicResume(4, "DESENVOLVEDOR JR .NET | TRAME & AUDIO PADRÃO | AGOSTO DE 2019 – SETEMBRO 2020", 5, true);

            st6.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Internalização de Software: Responsável pela transição técnica de um sistema de Saúde e Segurança Ocupacional (SST) antes gerido por consultoria externa para o ambiente interno da empresa."));
            st6.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Infraestrutura e Deploy: Publicação e manutenção da aplicação em ambiente de hospedagem IIS, incluindo o gerenciamento de servidores e estruturação do fluxo de versionamento de código."));
            st6.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Manutenção e Evolução: Desenvolvimento de novas funcionalidades e aplicação de manutenções preventivas em arquitetura monolítica, garantindo a estabilidade da plataforma."));
            st6.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Documentação Técnica: Elaboração de diagramas UML e documentação de código para facilitar a manutenção futura e a escalabilidade do sistema. \n \n"));


            subTopicThird.Add(st6);

            SubTopicResume st7 = new SubTopicResume(4, "Estagiário em .NET / Desenvolvedor Web e Mobile | GRUPO GPS | OUTUBRO DE 2016 - JULHO 2019", 6, true);

            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Desenvolvimento de Sistema de Telefonia: Responsável pelo ciclo completo de um projeto monolítico para o portal interno da companhia, desde a modelagem UML e definição da arquitetura base até a implementação final."));
            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Gestão de Requisitos: Atuação direta com o cliente para a criação e validação de módulos funcionais, garantindo que o software atendesse às necessidades do negócio."));
            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Documentação e Implantação: Elaboração de documentação técnica de desenvolvimento e execução do processo de implantação (deploy) do sistema."));
            st7.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Desenvolvimento Mobile/Web: Transição para a célula de mobilidade após um ano, atuando no desenvolvimento de soluções voltadas para o segmento de prestação de serviços (limpeza), com foco na otimização de processos operacionais."));

            subTopicThird.Add(st7);

            SubTopicResume st8 = new SubTopicResume(4, "ESTAGIÁRIO | PGOPEN| FEVEREIRO DE 2016 – ABRIL 2016", 7, true);

            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 1, "Manutenção de computadores."));
            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 2, "Gerenciamento de projetos de desenvolvimento."));
            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 3, "Ajuste de códigos Java."));
            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 4, "Suporte aos desenvolvedores"));
            st8.ItemsSubTopic.Add(new ItemsSubTopicResume(3, 5, "Desenvolvimento de manuais para usuário e ajudas gerais no setor de TI. \n \n"));

            subTopicThird.Add(st8);

            TopicResume thirdTopic = new TopicResume("Experiência", 3, subTopicThird);

            topics.Add(thirdTopic);

            List<SubTopicResume> subTopicsFourth = new List<SubTopicResume>();

            SubTopicResume complmentaryInformationsTechnicalCourse = new SubTopicResume(1, "Curso Técnico de Informática - People - 2015", 1, false);
            subTopicsFourth.Add(complmentaryInformationsTechnicalCourse);

            SubTopicResume complmentaryInformationsPosTechnicalCourse = new SubTopicResume(1, "Curso pós-técnico desenvolvedor multiplataforma (web & mobile) – Senai informática - 2016", 2, false);
            subTopicsFourth.Add(complmentaryInformationsPosTechnicalCourse);

            SubTopicResume complmentaryInformationsEnglishCourse = new SubTopicResume(1, "Inglês: Nível intermediário I - CNA - 2012", 3, false);
            subTopicsFourth.Add(complmentaryInformationsEnglishCourse);

            TopicResume fourthTopic = new TopicResume("Informações Complementares", 4, subTopicsFourth);

            topics.Add(fourthTopic);

            return topics;
        }

        private static List<GeneralParameters> PopulateGeneralParameters(List<GeneralParameters> parameters)
        {
            parameters.Add(new GeneralParameters((ResumeParameters.CompleteName).ToString(), "Pedro Vinicius Rodrigues Furlan"));
            parameters.Add(new GeneralParameters((ResumeParameters.MartialStatus).ToString(), "Casado"));
            parameters.Add(new GeneralParameters((ResumeParameters.Address).ToString(), "Rua Nápoles, Jardim colibri Nº 415, Cotia/SP"));
            parameters.Add(new GeneralParameters((ResumeParameters.CellPhone).ToString(), "(11) 99708-3252"));
            parameters.Add(new GeneralParameters((ResumeParameters.Email).ToString(), "pedro.furlan1304@hotmail.com"));
            parameters.Add(new GeneralParameters((ResumeParameters.GitHubLink).ToString(), "https://github.com/pedrops123/pedrops123"));
            parameters.Add(new GeneralParameters((ResumeParameters.LinkedinLink).ToString(), "\n https://www.linkedin.com/in/pedro-vin%C3%ADcius-rodrigues-furlan-a691bb10a/"));

            return parameters;
        }
    }
}