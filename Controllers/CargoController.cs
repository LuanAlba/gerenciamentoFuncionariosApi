using gerenciamentoFuncionariosApi.Models;
using gerenciamentoFuncionariosApi.Service.CargoService;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamentoFuncionariosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoInterface;

        public CargoController(ICargoService cargoService)
        {
            _cargoInterface = cargoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CargoModel>>> GetCargos()
        {
            var response = await _cargoInterface.GetCargos();

            if(!response.Sucesso)
            {
                if(response.Data == null || response.Data.Count == 0)
                {
                    response.Mensagem = "Nenhum cargo foi encontrado";
                    return BadRequest(response.Mensagem);
                }

                BadRequest(response.Mensagem);
            }

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public ActionResult<CargoModel> GetCargoById(int id)
        {
            var response = _cargoInterface.GetCargoById(id);

            if(!response.Sucesso)
            {
                return BadRequest(response.Mensagem);
            }

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<CargoModel>> CreateCargo(CargoModel novoCargo)
        {
            var response = await _cargoInterface.CreateCargo(novoCargo);

            if(!response.Sucesso)
            {
                return BadRequest(response.Mensagem);
            }

            return Ok(response.Data);
        }

        [HttpPut]
        public async Task<ActionResult<CargoModel>> EditCargo(CargoModel editadoCargo)
        {
            var response = await _cargoInterface.EditCargo(editadoCargo);

            if(!response.Sucesso)
            {
                return BadRequest(response.Mensagem);
            }

            return Ok(response.Data);
        }

        [HttpDelete]
        public ActionResult<CargoModel> DeleteCargo(int id)
        {
            var response = _cargoInterface.DeleteCargo(id);

            if(!response.Sucesso)
            {
                return BadRequest(response.Mensagem);
            }

            return Ok(response.Data);
        }
    }
}