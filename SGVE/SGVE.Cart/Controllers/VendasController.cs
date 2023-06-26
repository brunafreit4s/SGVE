using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE.Cart.Data.ValueObjects;
using SGVE.Cart.Repository;
using Swashbuckle.AspNetCore.Annotations;

namespace SGVE.Cart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : Controller
    {
        private IVendasRepository _repository;

        public VendasController(IVendasRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Retorna lista de produtos",
            Description = "Retornos: <br>" +
            "HTTP 200: Lista de produtos existentes." + "<br>" +
            "HTTP 404: Nenhum registro encontrado.")]
        [Route("Consultar")]
        public async Task<ActionResult<IEnumerable<VendasVO>>> FindAll()
        {
            var Vendas = await _repository.FindAll();
            if (Vendas == null) { return NotFound(); }
            return Ok(Vendas);
        }
    }
}
