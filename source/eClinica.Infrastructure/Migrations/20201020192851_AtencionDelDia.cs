using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eClinica.Infrastructure.Migrations
{
    public partial class AtencionDelDia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtencionDelDia",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroHistoria = table.Column<int>(nullable: false),
                    NumeroDiario = table.Column<int>(nullable: false),
                    NumeroVida = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true),
                    NombreCliente = table.Column<string>(nullable: true),
                    TipoAtencion = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtencionDelDia", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtencionDelDia");
        }
    }
}
