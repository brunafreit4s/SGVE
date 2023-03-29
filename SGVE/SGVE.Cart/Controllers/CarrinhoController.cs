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
        //[Authorize]
        [Route("Consultar/{id}")]
        public async Task<ActionResult<CarrinhoVO>> FindById(string UserId)
        {
            var carrinho = await _repository.FindCarrinhoByUserId(UserId);
            if (carrinho == null) return NotFound();
            return Ok(carrinho);
        }
        
        [HttpPost]
        //[Authorize]
        [Route("Adicionar/{id}")]
        public async Task<ActionResult<CarrinhoVO>> Create(CarrinhoVO vo)
        {
            var carrinho = await _repository.SaveOrUpdateCarrinho(vo);
            if (carrinho == null) return NotFound();
            return Ok(carrinho);
        }

        [HttpPut]
        //[Authorize]
        [Route("Alterar/{id}")]
        public async Task<ActionResult<CarrinhoVO>> Update(CarrinhoVO vo)
        {
            var carrinho = await _repository.SaveOrUpdateCarrinho(vo);
            if (carrinho == null) return NotFound();
            return Ok(carrinho);
        }

        [HttpDelete]
        //[Authorize]
        [Route("Deletar/{id}")]
        public async Task<ActionResult<CarrinhoVO>> Delete(int id)
        {
            var status = await _repository.RemoveFromCarrinho(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
