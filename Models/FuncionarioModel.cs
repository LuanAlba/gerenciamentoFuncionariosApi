using System.ComponentModel.DataAnnotations;

namespace gerenciamentoFuncionariosApi.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int Salario { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime Admissao { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; } = null;
        public Endereco? Endereco { get; set; }
        public CargoModel? Cargo { get; set; }

        public FuncionarioModel()
        {
            
        }
    }
}