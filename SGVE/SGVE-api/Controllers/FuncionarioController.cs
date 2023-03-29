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
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _repository;

        public FuncionarioController(IFuncionarioRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Retorna lista de funcionários", Description = "Retornos: <br>" +
            "HTTP 200: Lista de funcionários existentes." + "<br>" +
            "HTTP 400: Erro de validação." + "<br>" +
            "HTTP 401: Acesso não autorizado." + "<br>" +
            "HTTP 404: Nenhum registro encontrado." + "<br>" +
            "HTTP 500: Erro de servidor.")]
        [Route("Consultar")]
        public async Task<ActionResult<IEnumerable<FuncionarioVO>>> FindAll()
        {
            var funcionarios = await _repository.FindAll();
            return Ok(funcionarios);
        }

        [HttpGet]
        [Authorize]
        [Route("Consultar/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var funcionario = await _repository.FindById(id);
            if (funcionario.Id <= 0) return NotFound();
            return Ok(funcionario);
        }

        [HttpPost]
        [Authorize]
        [Route("Adicionar")]
        public async Task<ActionResult<FuncionarioVO>> Create([FromBody]FuncionarioVO vo)
        {
            if (vo == null) return BadRequest();

            vo.Data_Cadastro = DateTime.Now;

            var funcionario = await _repository.Create(vo);
            return Ok(funcionario);
        }
        
        [HttpPut]
        [Authorize]
        [Route("Alterar")]
        public async Task<ActionResult<FuncionarioVO>> Update([FromBody] FuncionarioVO vo)
        {
            if (vo == null) return BadRequest();
            var funcionario = await _repository.Update(vo);
            return Ok(funcionario);
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
