using Microsoft.EntityFrameworkCore.Migrations;

namespace Portifolio.Infrastructure.Database.Migrations
{
    public partial class TrocaTipoColunaImhThumbWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_thumbnail",
                table: "Works");

            migrationBuilder.AddColumn<int>(
                name: "img_thumbnail_id",
                table: "Works",
                type: "INT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_thumbnail_id",
                table: "Works");

            migrationBuilder.AddColumn<string>(
                name: "img_thumbnail",
                table: "Works",
                type: "VARCHAR(100)",
                nullable: true);
        }
    }
}
