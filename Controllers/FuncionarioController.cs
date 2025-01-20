using gerenciamentoFuncionariosApi.Models;
using gerenciamentoFuncionariosApi.Service.FuncionarioService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace gerenciamentoFuncionariosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        //Injeção da dependência
        private readonly IFuncionarioService _funcionarioInterface;
        private readonly IMemoryCache _cache;

        public FuncionarioController(IFuncionarioService funcionarioInterface, IMemoryCache cache)
        {
            _funcionarioInterface = funcionarioInterface;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {

            const string cacheKey = "funcionarios";

            if (!_cache.TryGetValue(cacheKey, out ServiceResponse<List<FuncionarioModel>> funcionarios))
            {
                funcionarios = await _funcionarioInterface.GetFuncionarios();

                if (!funcionarios.Sucesso)
                {
                    if (funcionarios.Data == null || funcionarios.Data.Count == 0)
                    {
                        return BadRequest("Nenhum dado encontrado.");
                    }
                    return BadRequest(funcionarios.Mensagem);
                }

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3)
                };

                _cache.Set(cacheKey, funcionarios, cacheEntryOptions);
            }

            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            var response = _funcionarioInterface.GetFuncionarioById(id);

            if (!response.Sucesso)
                return BadRequest(response.Mensagem);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            var response = await _funcionarioInterface.CreateFuncionario(novoFuncionario);

            if (!response.Sucesso)
                return BadRequest(response.Mensagem);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<FuncionarioModel>> UpdateFuncionario(FuncionarioModel novoFuncionario)
        {
            var response = await _funcionarioInterface.EditFuncionario(novoFuncionario);

            if (!response.Sucesso)
                return BadRequest(response.Mensagem);

            return Ok(response);
        }

        [HttpPatch("inativarFuncionario")]
        public ActionResult<FuncionarioModel> InativarFuncionario(int id)
        {
            var response = _funcionarioInterface.InativaFuncionario(id);

            if (!response.Sucesso)
                return BadRequest(response.Mensagem);

            return Ok(response);
        }

        [HttpDelete]
        public ActionResult<ServiceResponse<FuncionarioModel>> DeleteFuncionario(int id)
        {
            var response = _funcionarioInterface.DeleteFuncionario(id);

            if (!response.Sucesso)
                return BadRequest(response.Mensagem);

            return Ok(response);
        }
    }
}