using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portifolio.Domain.Entities;

namespace Portifolio.Infrastructure.Database.EntityFramework.Mappings
{
    public  class WorksMapper : IEntityTypeConfiguration<Works>
    {
        public void Configure(EntityTypeBuilder<Works> builder)
        {
            builder.ToTable(nameof(Works));
        }
    }
}
