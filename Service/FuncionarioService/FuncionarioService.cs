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
                serviceResponse.Data = await _context.Funcionarios.ToListAsync();

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

        public ServiceResponse<FuncionarioModel> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.SingleOrDefault(o => o.Id == id)!;

                if (funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Data = funcionario;
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

        public async Task<ServiceResponse<FuncionarioModel>> EditFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(o => o.Id == editadoFuncionario.Id)!;

                if (funcionario == null)
                {
                    serviceResponse.Mensagem = "Funcionário não localizado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                funcionario.AlteradoEm = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = funcionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }



        public ServiceResponse<FuncionarioModel> InativaFuncionario(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.SingleOrDefault(o => o.Id == id)!;

                if (funcionario == null)
                {
                    serviceResponse.Mensagem = "Funcionário não localizado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                funcionario.Ativo = false;
                funcionario.AlteradoEm = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                _context.SaveChanges();

                serviceResponse.Data = funcionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public ServiceResponse<FuncionarioModel> DeleteFuncionario(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id)!;

                if (funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Mensagem = "Funcionário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                var enderecoFuncionario = _context.Funcionarios.Include(o => o.Endereco).FirstOrDefault(o => o.Id == id);

                if (enderecoFuncionario != null)
                {
                    // Deletar todos os endereços associados
                    _context.Enderecos.RemoveRange(funcionario.Endereco!);
                }

                    _context.Funcionarios.Remove(funcionario);
                    _context.SaveChanges();

                    serviceResponse.Data = funcionario;
                    serviceResponse.Mensagem = "Funcionário excluído!";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}