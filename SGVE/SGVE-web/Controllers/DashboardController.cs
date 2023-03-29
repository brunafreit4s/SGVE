using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Services;
using SGVE_web.Services.IServices;
using System.Web.Http;

namespace SGVE_web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProdutosService _produtosService;

        public DashboardController(IProdutosService produtosService)
        {
            _produtosService = produtosService ?? throw new ArgumentNullException(nameof(produtosService));
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            if (accessToken == null) { return RedirectToAction("Index", "Home"); }
            var Produtos = await _produtosService.FindAllProdutosChart(accessToken);
            return View(Produtos);
        }
    }
}
