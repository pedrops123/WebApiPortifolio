namespace Portifolio.Domain.Entities.MinIO
{
    public class MinIOConfigurations
    {
        public Connection Connection { get; set; }
        public Credentials Credentials { get; set; }
        public Buckets Buckets { get; set; }
    }
}
