using System.ComponentModel.DataAnnotations;
using gerenciamentoFuncionariosApi.Enums;

namespace gerenciamentoFuncionariosApi.Models
{
    public class CargoModel
    {
        [Key]
        public int Id { get; set;}
        public int FuncionarioId { get; set; }
        public string Name { get; set;} = "";
        public string Setor { get; set; } = "";
        public TurnoEnum Turno { get; set; }
        public PermissaoEnum Permissao { get; set; }
    }
}