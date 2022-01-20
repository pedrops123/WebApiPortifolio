using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portifolio.Infrastructure.Database.Migrations
{
    public partial class CriacaoWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_projeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img_thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descritivo_capa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    texto_projeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInsert = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdate = table.Column<int>(type: "int", nullable: true),
                    UdpatetDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
