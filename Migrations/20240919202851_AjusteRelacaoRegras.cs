using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamentoFuncionariosApi.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacaoRegras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Cargos");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId",
                unique: true,
                filter: "[EnderecoId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Cargos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId");
        }
    }
}
