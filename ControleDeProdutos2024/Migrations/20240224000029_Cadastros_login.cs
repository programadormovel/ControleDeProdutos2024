using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeProdutos2024.Migrations
{
    /// <inheritdoc />
    public partial class Cadastros_login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelAcesso = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    EmailConfirmacao = table.Column<bool>(type: "bit", nullable: true),
                    TelefoneConfirmacao = table.Column<bool>(type: "bit", nullable: true),
                    DataDeRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");
        }
    }
}
