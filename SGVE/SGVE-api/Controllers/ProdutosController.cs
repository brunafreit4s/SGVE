using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE_api.Data.ValueObjects;
using SGVE_api.Repository;
using SGVE_api.Util;
using Swashbuckle.AspNetCore.Annotations;

namespace SGVE_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private IProdutosRepository _repository;

        public ProdutosController(IProdutosRepository repository)
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
        public async Task<ActionResult<IEnumerable<ProdutosVO>>> FindAll()
        {
            var Produtos = await _repository.FindAll();
            if(Produtos == null) { return NotFound(); }
            return Ok(Produtos);
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Retorna produto",
            Description = "Retornos: <br>" +
            "HTTP 200: Produto existente." + "<br>" +
            "HTTP 404: Nenhum registro encontrado.")]
        [Route("Consultar/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var Produtos = await _repository.FindById(id);
            if (Produtos.Id <= 0) return NotFound();
            return Ok(Produtos);
        }
        
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Retorna produto",
            Description = "Retornos: <br>" +
            "HTTP 200: Produto existente." + "<br>" +
            "HTTP 404: Nenhum registro encontrado.")]
        [Route("Consultar/{name}")]
        public async Task<IActionResult> FindByName(string name)
        {
            var Produtos = await _repository.FindByName(name);
            if (Produtos.Id <= 0) return NotFound();
            return Ok(Produtos);
        }

        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Insere produto",
            Description = "Retornos: <br>" +
            "HTTP 200: Inserido com Sucesso." + "<br>" +
            "HTTP 400: Erro de validação.")]
        [Route("Adicionar")]
        public async Task<ActionResult<ProdutosVO>> Create([FromBody] ProdutosVO vo)
        {
            if (vo == null) return BadRequest();

            vo.Data_Cadastro = DateTime.Now;

            var Produtos = await _repository.Create(vo);
            return Ok(Produtos);
        }

        [HttpPut]
        [Authorize]
        [SwaggerOperation(Summary = "Atualiza Produto",
            Description = "Retornos: <br>" +
            "HTTP 200: Atualizado os dados do produto com Sucesso." + "<br>" +
            "HTTP 400: Erro de validação.")]
        [Route("Alterar")]
        public async Task<ActionResult<ProdutosVO>> Update([FromBody] ProdutosVO vo)
        {
            if (vo == null) return BadRequest();
            var Produtos = await _repository.Update(vo);
            return Ok(Produtos);
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        [SwaggerOperation(Summary = "Exclui produto",
            Description = "Retornos: <br>" +
            "HTTP 200: Excluído com Sucesso." + "<br>" +
            "HTTP 400: Erro de validação.")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteById(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
