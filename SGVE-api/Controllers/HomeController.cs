using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGVE_api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SGVE_api.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost("/Home/Login")]
        public JsonResult Login(USUARIO parametros)
        {
            var retorno = new USUARIO();

            if(parametros.email != "" && parametros.senha != "")
            {
                retorno.email = "";
            }
            else
            {
                retorno.email = "";
            }

            return Json(retorno);
        }

        [HttpGet("/Home/DadosUsuario")]
        public JsonResult Get_DadosUsuario(USUARIO parametros)
        {
            var retorno = new USUARIO();

            if (parametros.email != "" && parametros.senha != "")
            {
                retorno.email = "";
            }
            else
            {
                retorno.email = "";
            }

            return Json(retorno);
        }
    }
}
