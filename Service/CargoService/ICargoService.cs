using gerenciamentoFuncionariosApi.Models;

namespace gerenciamentoFuncionariosApi.Service.CargoService
{
    public interface ICargoService
    {
        Task<ServiceResponse<List<CargoModel>>> GetCargos();
        ServiceResponse<CargoModel> GetCargoById(int id);
        Task<ServiceResponse<CargoModel>> CreateCargo(CargoModel novoCargo);
        Task<ServiceResponse<CargoModel>> EditCargo(CargoModel editadoCargo);
        ServiceResponse<CargoModel> DeleteCargo(int id);
    }
}