using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGVE_api.Data.ValueObjects;
using SGVE_api.Repository;

namespace SGVE_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _repository;

        public FuncionarioController(IFuncionarioRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Route("Consultar")]
        public async Task<ActionResult<IEnumerable<FuncionarioVO>>> FindAll()
        {
            var funcionarios = await _repository.FindAll();
            return Ok(funcionarios);
        }

        [HttpGet]
        [Route("Consultar/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var funcionario = await _repository.FindById(id);
            if (funcionario.Id <= 0) return NotFound();
            return Ok(funcionario);
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<ActionResult<FuncionarioVO>> Create([FromBody]FuncionarioVO vo)
        {
            if (vo == null) return BadRequest();
            var funcionario = await _repository.Create(vo);
            return Ok(funcionario);
        }
        
        [HttpPut]
        [Route("Alterar")]
        public async Task<ActionResult<FuncionarioVO>> Update([FromBody] FuncionarioVO vo)
        {
            if (vo == null) return BadRequest();
            var funcionario = await _repository.Update(vo);
            return Ok(funcionario);
        }

        [HttpDelete]
        [Route("Excluir")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteById(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
