﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portifolio.Infrastructure.Database.EntityFramework;

namespace Portifolio.Infrastructure.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Portifolio.Domain.Entities.GalleryWorks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProjeto")
                        .HasColumnType("INT");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("PathFile")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("DATETIME2");

                    b.Property<int>("UserInsert")
                        .HasColumnType("INT");

                    b.Property<int?>("UserUpdate")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("IdProjeto");

                    b.ToTable("GalleryWorks");
                });

            modelBuilder.Entity("Portifolio.Domain.Entities.Works", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("DATETIME2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("DATETIME2");

                    b.Property<int>("UserInsert")
                        .HasColumnType("INT");

                    b.Property<int?>("UserUpdate")
                        .HasColumnType("INT");

                    b.Property<string>("descritivo_capa")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("img_thumbnail")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("nome_projeto")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("texto_projeto")
                        .HasColumnType("VARCHAR(500)");

                    b.HasKey("Id");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("Portifolio.Domain.Entities.GalleryWorks", b =>
                {
                    b.HasOne("Portifolio.Domain.Entities.Works", "Work")
                        .WithMany("Fotos")
                        .HasForeignKey("IdProjeto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Work");
                });

            modelBuilder.Entity("Portifolio.Domain.Entities.Works", b =>
                {
                    b.Navigation("Fotos");
                });
#pragma warning restore 612, 618
        }
    }
}
