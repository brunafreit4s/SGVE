using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Services.IServices;

namespace SGVE_web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IProdutosService _produtosService;

        public DashboardController(ILogger<DashboardController> logger, IProdutosService produtosService)
        {
            _logger = logger;
            _produtosService = produtosService;
        }
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */

            if (accessToken == null) { return RedirectToAction("Index", "Home"); }

            var produtos = await _produtosService.FindAllProdutosChart(accessToken);
            return View(produtos);
        }
    }
}
