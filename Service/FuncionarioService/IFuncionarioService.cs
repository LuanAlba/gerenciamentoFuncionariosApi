using gerenciamentoFuncionariosApi.Models;

namespace gerenciamentoFuncionariosApi.Service.FuncionarioService
{
    public interface IFuncionarioService
    {
        //Lembrando que Tasks são utilizadas para métodos assíncronos
        //ServiceResponse irá receber uma lista de FuncionarioModel.
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
        ServiceResponse<FuncionarioModel> GetFuncionarioById(int id);
        Task<ServiceResponse<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario);
        Task<ServiceResponse<FuncionarioModel>> EditFuncionario(FuncionarioModel editadoFuncionario);
        ServiceResponse<FuncionarioModel> InativaFuncionario(int id);
        ServiceResponse<FuncionarioModel> DeleteFuncionario(int id);
    }
}