using Microsoft.EntityFrameworkCore.Migrations;

namespace Portifolio.Infrastructure.Database.Migrations
{
    public partial class CorrecaoNomenclaturaUpdateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UdpatetDate",
                table: "Works",
                newName: "UpdateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Works",
                newName: "UdpatetDate");
        }
    }
}
