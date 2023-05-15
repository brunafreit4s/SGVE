using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE_api.Data.ValueObjects;
using SGVE_api.Repository;
using Swashbuckle.AspNetCore.Annotations;

namespace SGVE_api.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoRepository _repository;

        public EnderecoController(IEnderecoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Retorna lista de endereços", 
            Description = "Retornos: <br>" +
            "HTTP 200: Lista de endereços existentes." + "<br>" +
            "HTTP 404: Nenhum registro encontrado.")]
        [Route("Consultar")]
        public async Task<ActionResult<IEnumerable<EnderecoVO>>> FindAll()
        {
            var enderecos = await _repository.FindAll();
            if(enderecos == null) { return NotFound(); }
            return Ok(enderecos);
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Retorna endereço",
            Description = "Retornos: <br>" +
            "HTTP 200: Endereço existente." + "<br>" +
            "HTTP 404: Nenhum registro encontrado.")]
        [Route("Consultar/{cep}")]
        public async Task<IActionResult> FindByCep(int cep)
        {
            var funcionario = await _repository.FindByCep(cep);
            if (funcionario._id <= 0) return NotFound();
            return Ok(funcionario);
        }

    }
}
