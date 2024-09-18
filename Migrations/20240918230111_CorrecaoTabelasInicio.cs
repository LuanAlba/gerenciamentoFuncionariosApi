using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamentoFuncionariosApi.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTabelasInicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cargos",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cargos",
                newName: "Name");
        }
    }
}
