using System.ComponentModel.DataAnnotations;

namespace gerenciamentoFuncionariosApi.Models
{
    public class CargoModel
    {
        [Key]
        public int Id { get; set;}
        public int? FuncionarioId { get; set; }
        public string Name { get; set;} = "";
        public string Setor { get; set; } = "";
        
    }
}