using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portifolio.Domain.Entities;

namespace Portifolio.Infrastructure.Database.EntityFramework.Mappings.GalleryWork
{
    public class GalleryWorksMapper : IEntityTypeConfiguration<GalleryWorks>
    {
        public void Configure(EntityTypeBuilder<GalleryWorks> builder)
        {
            builder.ToTable(nameof(GalleryWorks));
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Comment)
                .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.PathFile)
                .HasColumnType("VARCHAR(500)");

            builder.Property(r => r.ProjectId)
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
                .WithMany(f => f.Photos)
                .HasForeignKey(f => f.ProjectId);
        }
    }
}
