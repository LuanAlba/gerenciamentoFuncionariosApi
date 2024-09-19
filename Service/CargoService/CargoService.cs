using gerenciamentoFuncionariosApi.DataContext;
using gerenciamentoFuncionariosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamentoFuncionariosApi.Service.CargoService
{
    public class CargoService : ICargoService
    {
        private readonly ApplicationDbContext _context;

        public CargoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CargoModel>>> GetCargos()
        {
            ServiceResponse<List<CargoModel>> serviceResponse = new ServiceResponse<List<CargoModel>>();

            try
            {
                serviceResponse.Data = await _context.Cargos.ToListAsync();

                if (serviceResponse.Data.Count == 0)
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public ServiceResponse<CargoModel> GetCargoById(int id)
        {
            ServiceResponse<CargoModel> serviceResponse = new ServiceResponse<CargoModel>();

            try
            {
                CargoModel cargo = _context.Cargos.SingleOrDefault(o => o.Id == id)!;

                if (cargo == null)
                {
                    serviceResponse.Mensagem = "Cargo não encontrado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Data = cargo;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CargoModel>> CreateCargo(CargoModel novoCargo)
        {
            ServiceResponse<CargoModel> serviceResponse = new ServiceResponse<CargoModel>();

            try
            {
                if (novoCargo == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Mensagem = "Insira os dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Cargos.Add(novoCargo);
                await _context.SaveChangesAsync();

                serviceResponse.Data = novoCargo;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CargoModel>> EditCargo(CargoModel editadoCargo)
        {
            ServiceResponse<CargoModel> serviceResponse = new ServiceResponse<CargoModel>();

            try
            {
                CargoModel cargo = _context.Cargos.AsNoTracking().FirstOrDefault(o => o.Id == editadoCargo.Id)!;

                if (cargo == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Mensagem = "Cargo não encontrado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Cargos.Update(editadoCargo);
                await _context.SaveChangesAsync();

                serviceResponse.Data = editadoCargo;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public ServiceResponse<CargoModel> DeleteCargo(int id)
        {
            ServiceResponse<CargoModel> serviceResponse = new ServiceResponse<CargoModel>();

            try
            {
                CargoModel cargo = _context.Cargos.SingleOrDefault(o => o.Id == id)!;

                if (cargo == null)
                {
                    serviceResponse.Mensagem = "Cargo não encontrado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Cargos.Remove(cargo);
                _context.SaveChanges();

                serviceResponse.Data = cargo;
                serviceResponse.Mensagem = "Cargo excluído";
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