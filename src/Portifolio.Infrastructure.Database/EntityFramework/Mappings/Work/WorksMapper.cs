using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portifolio.Domain.Entities;

namespace Portifolio.Infrastructure.Database.EntityFramework.Mappings.Work
{
    public class WorksMapper : IEntityTypeConfiguration<Works>
    {
        public void Configure(EntityTypeBuilder<Works> builder)
        {
            builder.ToTable(nameof(Works));

            builder.HasKey(r => r.Id);

            builder.Property(r => r.ImgThumbnailId)
                    .HasColumnType("INT");

            builder.Property(r => r.ProjectName)
                    .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.DescriptionCover)
                   .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.ProjectText)
                   .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.InsertDate)
                    .HasColumnType("DATETIME2");

            builder.Property(r => r.UserInsert)
                .HasColumnType("INT");

            builder.Property(r => r.UpdateDate)
                .HasColumnType("DATETIME2");

            builder.Property(r => r.UserUpdate)
                .HasColumnType("INT");

            builder.HasMany(r => r.Photos)
                .WithOne(r => r.Work)
                .HasForeignKey(r => r.ProjectId);
        }
    }
}