using gerenciamentoFuncionariosApi.Models;

namespace gerenciamentoFuncionariosApi.Service.FuncionarioService
{
    public interface IFuncionarioService
    {
        //Lembrando que Tasks são utilizadas para métodos assíncronos
        //ServiceResponse irá receber uma lista de FuncionarioModel.
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();

        //ServiceResponse irá receber um FuncionarioModel.
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);

        //ServiceResponse irá receber um model de um novo Funcionario que acaba de ser inserido.
        Task<ServiceResponse<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario);

        //ServiceResponse irá receber um model de um Funcionario que acaba de ser editado.
        Task<ServiceResponse<FuncionarioModel>> EditFuncionario(FuncionarioModel editadoFuncionario);

        //ServiceResponse irá receber um model de um Funcionario que será alterado atraves do Id para alterar o estado da propriedade Ativo para false.
        Task<ServiceResponse<FuncionarioModel>> InativaFuncionario(int id);
    }
}