using Microsoft.EntityFrameworkCore.Migrations;

namespace Portifolio.Infrastructure.Database.Migrations
{
    public partial class RemocaochaveDesnecessariaWorkThumb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_GalleryWorks_img_thumbnailId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_img_thumbnailId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "img_thumbnailId",
                table: "Works");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "img_thumbnailId",
                table: "Works",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_img_thumbnailId",
                table: "Works",
                column: "img_thumbnailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_GalleryWorks_img_thumbnailId",
                table: "Works",
                column: "img_thumbnailId",
                principalTable: "GalleryWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
