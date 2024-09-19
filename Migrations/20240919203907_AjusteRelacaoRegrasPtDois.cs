using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamentoFuncionariosApi.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacaoRegrasPtDois : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Enderecos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FuncionarioId",
                table: "Enderecos",
                column: "FuncionarioId",
                unique: true,
                filter: "[FuncionarioId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Funcionarios_FuncionarioId",
                table: "Enderecos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Funcionarios_FuncionarioId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_FuncionarioId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Enderecos");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId",
                unique: true,
                filter: "[EnderecoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }
    }
}
