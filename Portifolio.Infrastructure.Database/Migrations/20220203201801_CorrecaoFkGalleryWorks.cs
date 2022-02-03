using Microsoft.EntityFrameworkCore.Migrations;

namespace Portifolio.Infrastructure.Database.Migrations
{
    public partial class CorrecaoFkGalleryWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryWorks_Works_WorkId",
                table: "GalleryWorks");

            migrationBuilder.DropIndex(
                name: "IX_GalleryWorks_WorkId",
                table: "GalleryWorks");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "GalleryWorks");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryWorks_IdProjeto",
                table: "GalleryWorks",
                column: "IdProjeto");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryWorks_Works_IdProjeto",
                table: "GalleryWorks",
                column: "IdProjeto",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryWorks_Works_IdProjeto",
                table: "GalleryWorks");

            migrationBuilder.DropIndex(
                name: "IX_GalleryWorks_IdProjeto",
                table: "GalleryWorks");

            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "GalleryWorks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GalleryWorks_WorkId",
                table: "GalleryWorks",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryWorks_Works_WorkId",
                table: "GalleryWorks",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
