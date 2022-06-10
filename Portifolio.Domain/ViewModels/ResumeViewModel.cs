using Portifolio.Domain.Entities;
using Portifolio.Domain.Entities.PdfResume;
using System.Collections.Generic;

namespace Portifolio.Domain.ViewModels
{
    public sealed class ResumeViewModel
    {
        public ICollection<GeneralParameters> InitialParameters { get; private set; }

        public ICollection<TopicResume> Topics { get; set; }

        public IEnumerable<string> ListOfTopicsTechnologies { get; private set; }

        public IEnumerable<string[]> ListOfKnowlegesTechnologies { get; private set; }

        public IEnumerable<string> ListOfTopicsFrameworks { get; private set; }

        public IEnumerable<string[]> ListOfKnowlegesFrameworks { get; private set; }

        public ResumeViewModel(
            ICollection<GeneralParameters> initialParameters,
            ICollection<TopicResume> topics,
            IEnumerable<string> listOfTopicsTechnologies,
            IEnumerable<string[]> listOfKnowlegesTechnologies,
            IEnumerable<string> listOfTopicsFrameworks,
            IEnumerable<string[]> listOfKnowlegesFrameworks)
        {
            InitialParameters = initialParameters;
            Topics = topics;
            ListOfTopicsTechnologies = listOfTopicsTechnologies;
            ListOfKnowlegesTechnologies = listOfKnowlegesTechnologies;
            ListOfTopicsFrameworks = listOfTopicsFrameworks;
            ListOfKnowlegesFrameworks = listOfKnowlegesFrameworks;
        }

        private ResumeViewModel()
        { }
    }
}
