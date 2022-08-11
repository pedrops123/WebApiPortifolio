using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portifolio.Infrastructure.Database.Migrations
{
    public partial class MudançaNomenclaturasEntidadesPTToEnglish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    ImgThumbnailId = table.Column<int>(type: "INT", nullable: true),
                    DescriptionCover = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    ProjectText = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    UserInsert = table.Column<int>(type: "INT", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    UserUpdate = table.Column<int>(type: "INT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "INT", nullable: false),
                    PathFile = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    Comment = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    UserInsert = table.Column<int>(type: "INT", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    UserUpdate = table.Column<int>(type: "INT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryWorks_Works_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryWorks_ProjectId",
                table: "GalleryWorks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryWorks");

            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
