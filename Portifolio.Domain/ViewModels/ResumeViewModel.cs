using Portifolio.Domain.Entities;
using Portifolio.Domain.Entities.PdfResume;
using System.Collections.Generic;

namespace Portifolio.Domain.ViewModels
{
    public sealed class ResumeViewModel
    {
        public ICollection<GeneralParameters> InitialParameters { get; private set; }

        public ICollection<TopicResume> Topics { get; set; }


        public ResumeViewModel(
            List<GeneralParameters> initialParameters,
            List<TopicResume> topics)
        {
            InitialParameters = initialParameters;
            Topics = topics;
        }

        private ResumeViewModel()
        { }
    }
}
