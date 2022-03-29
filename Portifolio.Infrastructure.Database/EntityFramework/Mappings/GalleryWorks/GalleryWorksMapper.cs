using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portifolio.Infrastructure.Database.EntityFramework.Mappings.GalleryWorks
{
    public class GalleryWorksMapper : IEntityTypeConfiguration<Domain.Entities.GalleryWorks>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.GalleryWorks> builder)
        {
            builder.ToTable(nameof(Domain.Entities.GalleryWorks));
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Comment)
                .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.PathFile)
                .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.IdProjeto)
                .HasColumnType("INT");

            builder.Property(r => r.InsertDate)
                .HasColumnType("DATETIME2");

            builder.Property(r => r.UserInsert)
                .HasColumnType("INT");

            builder.Property(r => r.UpdateDate)
                .HasColumnType("DATETIME2");

            builder.Property(r => r.UserUpdate)
                .HasColumnType("INT");

            builder.HasOne(f => f.Work)
                .WithMany(f => f.Fotos)
                .HasForeignKey(f => f.IdProjeto);
        }
    }
}
