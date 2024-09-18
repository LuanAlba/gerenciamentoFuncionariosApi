using gerenciamentoFuncionariosApi.DataContext;
using gerenciamentoFuncionariosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamentoFuncionariosApi.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioService
    {

        private readonly ApplicationDbContext _context;

        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {

           ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Data = await  _context.Funcionarios.ToListAsync();

                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Mensagem = "Informe dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = novoFuncionario;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<FuncionarioModel>> EditFuncionario(FuncionarioModel editadoFuncionario)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<ServiceResponse<FuncionarioModel>> InativaFuncionario(int id)
        {
            throw new NotImplementedException();
        }
    }
}