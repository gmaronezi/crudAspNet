using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDWEB2.Api.Migrations
{
    public partial class Teste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 160, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(maxLength: 11, nullable: true),
                    Rua = table.Column<string>(maxLength: 160, nullable: true),
                    Numero = table.Column<int>(maxLength: 6, nullable: false),
                    Complemento = table.Column<string>(maxLength: 200, nullable: true),
                    Bairro = table.Column<string>(maxLength: 160, nullable: true),
                    Cep = table.Column<string>(maxLength: 12, nullable: true),
                    CidadeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CidadeId",
                table: "Cliente",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
