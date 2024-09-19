using System.ComponentModel.DataAnnotations;
using gerenciamentoFuncionariosApi.Enums;

namespace gerenciamentoFuncionariosApi.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int Salario { get; set; }
        public bool Ativo { get; set; } = true;
        public TurnoEnum Turno { get; set; }
        public DateTime Admissao { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; } = null;
        public int? CargoId { get; set; }

        public virtual Endereco? Endereco { get; set; }

        public FuncionarioModel()
        {
            
        }
    }
}