using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE.Cart.Data.ValueObjects;
using SGVE.Cart.Repository;
using Swashbuckle.AspNetCore.Annotations;

namespace SGVE.Cart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : Controller
    {
        private ICarrinhoRepository _repository;

        public CarrinhoController(ICarrinhoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Retorna lista de Vendas",
            Description = "Retornos: <br>" +
            "HTTP 200: Lista de funcionários existentes." + "<br>" +
            "HTTP 404: Nenhum registro encontrado.")]
        [Route("Consultar/{userId}")]
        public async Task<IActionResult> FindById(string userId)
        {
            var carrinho = await _repository.FindCarrinhoByUserId(userId);
            if (carrinho == null) return NotFound();
            else if (carrinho.CartDetails == null) return NotFound();
            return Ok(carrinho);
        }
        
        [HttpPost]
        [Authorize]
        [Route("Adicionar")]
        public async Task<ActionResult<CartVO>> Create([FromBody] CartVO vo)
        {            
            var carrinho = await _repository.SaveOrUpdateCarrinho(vo);
            if (carrinho == null) return NotFound();
            return Ok(carrinho);
        }

        [HttpPut]
        [Authorize]
        [Route("Alterar")]
        public async Task<ActionResult<CartVO>> Update([FromBody] CartVO vo)
        {
            var carrinho = await _repository.SaveOrUpdateCarrinho(vo);
            if (carrinho == null) return NotFound();
            return Ok(carrinho);
        }

        [HttpDelete]
        [Authorize]
        [Route("Deletar/{id}")]
        public async Task<ActionResult<CartVO>> Delete(int id)
        {
            var status = await _repository.RemoveFromCarrinho(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpGet]
        [Authorize]
        [Route("Limpar/{userId}")]
        public async Task<ActionResult> Limpar(string userId)
        {
            var status = await _repository.ClearCarrinho(userId);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
