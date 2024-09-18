using gerenciamentoFuncionariosApi.Models;
using gerenciamentoFuncionariosApi.Service.FuncionarioService;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamentoFuncionariosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        //Injeção da dependência
        private readonly IFuncionarioService _funcionarioInterface;

        public FuncionarioController(IFuncionarioService funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            // return Ok(await _funcionarioInterface.GetFuncionarios());
            var response = await _funcionarioInterface.GetFuncionarios();
            if (!response.Sucesso)
            {
                if (response.Data == null || response.Data.Count == 0)
                {
                    return BadRequest("Nenhum dado encontrado.");
                }
                return BadRequest(response.Mensagem);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }
    }
}