using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Models;
using SGVE_web.Services.IServices;
using System.Diagnostics;

namespace SGVE_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFuncionarioService _funcionarioService;

        public HomeController(ILogger<HomeController> logger, IFuncionarioService funcionarioService)
        {
            _logger = logger;
            _funcionarioService = funcionarioService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            //var funcionarios = await _funcionarioService.FindAllFuncionarios(accessToken);
            return View();//funcionarios);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */

            if (accessToken == null) { return RedirectToAction("Index", "Home"); }

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc"); // Remove os cookies de acesso. oidc: open id connection
        }
    }
}