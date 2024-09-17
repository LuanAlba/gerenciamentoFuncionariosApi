namespace gerenciamentoFuncionariosApi.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}