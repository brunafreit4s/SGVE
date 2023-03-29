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
        [SwaggerOperation(Summary = "Retorna lista de Produtos", Description = "Retornos: <br>" +
            "HTTP 200: Lista de Produtos existentes." + "<br>" +
            "HTTP 400: Erro de validação." + "<br>" +
            "HTTP 401: Acesso não autorizado." + "<br>" +
            "HTTP 404: Nenhum registro encontrado." + "<br>" +
            "HTTP 500: Erro de servidor.")]
        [Route("Consultar")]
        public async Task<ActionResult<IEnumerable<ProdutosVO>>> FindAll()
        {
            var Produtoss = await _repository.FindAll();
            return Ok(Produtoss);
        }

        [HttpGet]
        [Authorize]
        [Route("Consultar/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var Produtos = await _repository.FindById(id);
            if (Produtos.Id <= 0) return NotFound();
            return Ok(Produtos);
        }

        [HttpPost]
        [Authorize]
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
        [Route("Alterar")]
        public async Task<ActionResult<ProdutosVO>> Update([FromBody] ProdutosVO vo)
        {
            if (vo == null) return BadRequest();
            var Produtos = await _repository.Update(vo);
            return Ok(Produtos);
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteById(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
