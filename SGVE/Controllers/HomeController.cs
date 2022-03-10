using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGVE.Models;

namespace SGVE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "SGVEC - Área de Acesso";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Dashboard()
        {            
            ViewData["Message"] = "Seja bem vindo(a) ";

            return View();
        }

        [HttpPost]
        public ActionResult ValidarAcesso(USUARIO vData)
        {
            //var teste = vData.LOGIN;
            return RedirectToAction("Dashboard");
        }
    }
}
