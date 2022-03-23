using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portifolio.Infrastructure.Database.EntityFramework.Mappings.Works
{
    public class WorksMapper : IEntityTypeConfiguration<Domain.Entities.Works>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Works> builder)
        {
            builder.ToTable(nameof(Domain.Entities.Works));

            builder.HasKey(r => r.Id);

            builder.Property(r => r.img_thumbnail_id)
                    .HasColumnType("INT");

            builder.Property(r => r.nome_projeto)
                    .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.descritivo_capa)
                   .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.texto_projeto)
                   .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.InsertDate)
                    .HasColumnType("DATETIME2");

            builder.Property(r => r.UserInsert)
                .HasColumnType("INT");

            builder.Property(r => r.UpdateDate)
                .HasColumnType("DATETIME2");

            builder.Property(r => r.UserUpdate)
                .HasColumnType("INT");

            builder.HasMany(r => r.Fotos)
                .WithOne(r => r.Work);

            builder.HasOne(r=>r.img_thumbnail)
                .WithOne(r=>r.Work).ii
        }
    }
}
