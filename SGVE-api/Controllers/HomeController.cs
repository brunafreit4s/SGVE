using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGVE_api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SGVE.Models;
using SGVE_api.EntityStore;
using Microsoft.AspNetCore.Http;

namespace SGVE_api.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        [ProducesResponseType(typeof(List<Usuario>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Retorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Retorno), StatusCodes.Status500InternalServerError)]
        [HttpPost("api/Home/DadosUsuario/")]
        public IActionResult Get_DadosUsuario([FromBody] Usuario vData)
        {
            try
            {
                var retorno = _context.Funcionario.FirstOrDefault(u => u.EMAIL_FUNC == vData.EMAIL_FUNC && u.SENHA_FUNC == vData.SENHA_FUNC);

                if (retorno != null)
                {
                    return Json(retorno);
                }
                else
                {
                    return BadRequest(retorno);
                }
            }
            catch(Exception ex)
            {
                ERRO objErro = new ERRO();
                objErro.strErro = "Erro Interno no Servidor: " + ex.Message;
                return StatusCode((int)StatusCodes.Status500InternalServerError, objErro.strErro);
            }
        }

        [HttpPost("api/Home/AdicionaUsuario")]
        public JsonResult Post_DadosUsuario(Usuario parametros)
        {
            try
            {
                _context.Funcionario.Add(parametros);
                _context.SaveChanges();

                return Json(_context);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
