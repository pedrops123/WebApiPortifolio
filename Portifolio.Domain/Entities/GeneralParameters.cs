namespace Portifolio.Domain.Entities
{
    public sealed class GeneralParameters : BaseEntity
    {
        public string Key { get; private set; }

        public string Value { get; private set; }

        private GeneralParameters()
        { }

        public GeneralParameters(
            string key,
            string value)
        {
            Key = key;
            Value = value;
        }
    }
}