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

namespace SGVE_api.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("api/Home/DadosUsuario")]
        public JsonResult Get_DadosUsuario(USUARIO parametros)
        {
            var _retorno = 0;

            try
            {
                _context.Funcionario.FirstOrDefault(u => u.EMAIL_FUNC == parametros.EMAIL_FUNC && u.SENHA_FUNC == parametros.SENHA_FUNC);

                _retorno = 1;

                return Json(_retorno);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("api/Home/AdicionaUsuario")]
        public JsonResult Post_DadosUsuario(USUARIO parametros)
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
