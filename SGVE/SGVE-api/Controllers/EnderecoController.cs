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
    }
}
