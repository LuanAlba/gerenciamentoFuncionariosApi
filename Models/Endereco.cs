using System.ComponentModel.DataAnnotations;

namespace gerenciamentoFuncionariosApi.Models
{
    public class Endereco{
        [Key]
        public int Id { get; set;}
        public int FuncionarioId { get; set; }
        public string Pais { get; set; } = string.Empty;
        public string Estado { get; set; }= string.Empty;
        public string Cidade { get; set; }= string.Empty;

        public Endereco()
        {
            
        }
    }
}