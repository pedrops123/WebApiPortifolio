using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portifolio.Infrastructure.Database.Migrations
{
    public partial class InclusaoGaleriaFotosWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "texto_projeto",
                table: "Works",
                type: "VARCHAR(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome_projeto",
                table: "Works",
                type: "VARCHAR(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "img_thumbnail",
                table: "Works",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descritivo_capa",
                table: "Works",
                type: "VARCHAR(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserUpdate",
                table: "Works",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserInsert",
                table: "Works",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Works",
                type: "DATETIME2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Works",
                type: "DATETIME2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "GalleryWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "INT", nullable: false),
                    PathFile = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    WorkId = table.Column<int>(type: "int", nullable: true),
                    UserInsert = table.Column<int>(type: "INT", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    UserUpdate = table.Column<int>(type: "INT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryWorks_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryWorks_WorkId",
                table: "GalleryWorks",
                column: "WorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryWorks");

            migrationBuilder.AlterColumn<string>(
                name: "texto_projeto",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome_projeto",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "img_thumbnail",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descritivo_capa",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserUpdate",
                table: "Works",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserInsert",
                table: "Works",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Works",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Works",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2");
        }
    }
}
